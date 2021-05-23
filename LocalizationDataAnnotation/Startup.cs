using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizationDataAnnotation
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
			services.AddControllersWithViews();

			services.AddMvc()
				// ���[�J���C�Y�ɕK�v�BResx �t�@�C���̃t�H���_�p�X���w��
				.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, opts => { opts.ResourcesPath = "Resources"; })
				// DataAnnotations �̃��[�J���C�Y�ɕK�v
				.AddDataAnnotationsLocalization(options =>
				 {
					 // DataAnnotation ���g�����Ƃ��̃��b�Z�[�W�� SharedResource �ɏW�񂷂�
					 options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(SharedResource));
				 });
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			// �W���̋@�\�Ő؂�ւ�����������`���܂��B
			var supportedCultures = new[]
			{
				new CultureInfo("ja"),
				new CultureInfo("en"),
				new CultureInfo("es"),
			};

			// �W���̌���؂�ւ��@�\��L���ɂ��܂��B�Ή����Ă���̂́u�N�G��������v�uCookie�v�uAccept-Language HTTP �w�b�_�[�v�ł��B
			app.UseRequestLocalization(new RequestLocalizationOptions
			{
				DefaultRequestCulture = new RequestCulture("ja"),
				SupportedCultures = supportedCultures,
				SupportedUICultures = supportedCultures
			}); 

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
									name: "default",
									pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
