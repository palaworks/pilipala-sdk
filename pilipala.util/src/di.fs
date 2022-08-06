module pilipala.util.di

open Microsoft.Extensions.DependencyInjection

type IServiceCollection with

    member inline self.UpdateScoped<'t when 't: not struct>(f: 't -> 't) =
        let old = self.BuildServiceProvider().GetService<'t>()

        self.AddScoped<'t>(fun _ -> f old)
        
    member inline self.UpdateSingleton<'t when 't: not struct>(f: 't -> 't) =
        let old = self.BuildServiceProvider().GetService<'t>()

        self.AddSingleton<'t>(fun _ -> f old)

    member inline self.UpdateAddTransient<'t when 't: not struct>(f: 't -> 't) =
        let old = self.BuildServiceProvider().GetService<'t>()

        self.AddTransient<'t>(fun _ -> f old)
