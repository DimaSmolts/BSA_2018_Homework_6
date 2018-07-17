using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BSA_2018_Homework_4
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			//DAL.MyContext temp = new


			services.AddScoped<BL.ServiceInterfaces.IPlaneService, BL.Services.PlaneService>();
			services.AddScoped<DAL.RepositoryInterfaces.IPlaneRepository, DAL.Repositories.PlaneRepository>();

			services.AddScoped<BL.ServiceInterfaces.ITicketService, BL.Services.TicketService>();
			services.AddScoped<DAL.RepositoryInterfaces.ITicketRepository, DAL.Repositories.TicketRepository>();

			services.AddScoped<BL.ServiceInterfaces.IPilotService, BL.Services.PilotService>();
			services.AddScoped<DAL.RepositoryInterfaces.IPilotRepository, DAL.Repositories.PilotRepository>();

			services.AddScoped<BL.ServiceInterfaces.IStewardessService, BL.Services.StewardessService>();
			services.AddScoped<DAL.RepositoryInterfaces.IStewardessRepository, DAL.Repositories.StewardessRepository>();

			services.AddScoped<BL.ServiceInterfaces.ITakeOffService, BL.Services.TakeOffService>();
			services.AddScoped<DAL.RepositoryInterfaces.ITakeOffRepository, DAL.Repositories.TakeOffRepository>();

			services.AddScoped<BL.ServiceInterfaces.IPlaneTypeService, BL.Services.PlaneTypeService>();
			services.AddScoped<DAL.RepositoryInterfaces.IPlaneTypeRepository, DAL.Repositories.PlaneTypeRepository>();

			services.AddScoped<BL.ServiceInterfaces.IFlightService, BL.Services.FlightService>();
			services.AddScoped<DAL.RepositoryInterfaces.IFlightRepository, DAL.Repositories.FlightRepository>();

			services.AddScoped<BL.ServiceInterfaces.ICrewService, BL.Services.CrewService>();
			services.AddScoped<DAL.RepositoryInterfaces.ICrewRepository, DAL.Repositories.CrewRepository>();

			///////////////////////////////////
			///////////////////////////////////
			///////////////////////////////////
			////Впишіть будь ласка стрічку підключення до свого серверу

			var connection = @"Server=DESKTOP-DMYTRO\SQLEXPRESS;Initial Catalog=Academy;Trusted_Connection=True;ConnectRetryCount=0";
			services.AddDbContext<DAL.MyContext>(options => options.UseSqlServer(connection));
			//var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;


			services.AddSingleton<DAL.IUnitOfWork, DAL.UnitOfWork>();

			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<DAL.Models.Plane, DTOs.PlaneDTO>()
				.ForMember(p => p.Type, dto => dto.MapFrom(src => src.Type));
				cfg.CreateMap<DTOs.PlaneDTO, DAL.Models.Plane>()
				.ForMember(dto => dto.Type, p => p.MapFrom(src => src.Type));

				cfg.CreateMap<DAL.Models.Flight, DTOs.FlightDTO>()
				.ForMember(f => f.FlightNum, dto => dto.MapFrom(src => src.FlightId));
				cfg.CreateMap<DTOs.FlightDTO, DAL.Models.Flight>()
				.ForMember(dto => dto.FlightId, f => f.MapFrom(src => src.FlightNum));

				cfg.CreateMap<DAL.Models.Ticket, DTOs.TicketDTO>()
				.ForMember(t => t.FlightNum, dto => dto.MapFrom(src => src.FlightNum));
				cfg.CreateMap<DTOs.TicketDTO, DAL.Models.Ticket>()
				.ForMember(dto => dto.FlightNum, t => t.MapFrom(src => src.FlightNum));

				cfg.CreateMap<DAL.Models.Crew, DTOs.CrewDTO>()
				.ForMember(c => c.PilotId, dto => dto.MapFrom(src => src.PilotId))
				.ForMember(c => c.StewardessIds, dto => dto.MapFrom(src => src.StewardessIds));
				cfg.CreateMap<DTOs.CrewDTO, DAL.Models.Crew>()
				.ForMember(dto => dto.StewardessIds, c => c.MapFrom(src => src.StewardessIds))
				.ForMember(dto => dto.PilotId, c => c.MapFrom(src => src.PilotId));

				cfg.CreateMap<DAL.Models.Pilot, DTOs.PilotDTO>();
				cfg.CreateMap<DTOs.PilotDTO, DAL.Models.Pilot>();

				cfg.CreateMap<DAL.Models.Stewardess, DTOs.StewardessDTO>();
				cfg.CreateMap<DTOs.StewardessDTO, DAL.Models.Stewardess>();

				cfg.CreateMap<DAL.Models.TakeOff, DTOs.TakeOffDTO>()
				.ForMember(dto => dto.PlaneId, to => to.MapFrom(src => src.PlaneId))
				.ForMember(dto => dto.CrewId, to => to.MapFrom(src => src.CrewId))
				.ForMember(dto => dto.FlightNum, to => to.MapFrom(src => src.FlightNum));
				cfg.CreateMap<DTOs.TakeOffDTO, DAL.Models.TakeOff>()
				.ForMember(to => to.CrewId, dto => dto.MapFrom(src => src.CrewId))
				.ForMember(to => to.PlaneId, dto => dto.MapFrom(src => src.PlaneId))
				.ForMember(to => to.FlightNum, dto => dto.MapFrom(src => src.FlightNum));


				cfg.CreateMap<DAL.Models.PlaneType, DTOs.PlaneTypeDTO>();
				cfg.CreateMap<DTOs.PlaneTypeDTO, DAL.Models.PlaneType>();
			});

			services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

			using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetRequiredService<DAL.MyContext>();
				context.Database.Migrate();
			}

			app.UseMvc();
        }
    }
}
