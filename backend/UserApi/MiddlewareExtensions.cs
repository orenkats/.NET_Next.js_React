namespace Microsoft.AspNetCore.Builder
{
    public static class MiddlewareExtensions
    {
        public static void ConfigureMiddleware(this WebApplication app)
        {
            // Use Swagger in development
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Use custom middleware for logging
            app.UseMiddleware<UserApi.WebApi.Middlewares.LoggingMiddleware>();

            // Use CORS
            app.UseCors("AllowFrontend");

            //app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
