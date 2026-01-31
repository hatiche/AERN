using System.Text;
using AERN.Api.Contracts;
using AERN.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPasskeyService, PasskeyService>();
builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<IAssetTypeService, AssetTypeService>();
builder.Services.AddScoped<IAssetLocationService, AssetLocationService>();
builder.Services.AddScoped<ITelemetryService, TelemetryService>();
builder.Services.AddScoped<ITelemetryAlertService, TelemetryAlertService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<IDocumentProcessingService, DocumentProcessingService>();
builder.Services.AddScoped<IMaintenanceWorkOrderService, MaintenanceWorkOrderService>();
builder.Services.AddScoped<IMaintenanceScheduleService, MaintenanceScheduleService>();
builder.Services.AddScoped<IInventoryPartService, InventoryPartService>();
builder.Services.AddScoped<IInventoryStockService, InventoryStockService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();
builder.Services.AddScoped<IConfigurationService, ConfigurationService>();
builder.Services.AddScoped<IIntegrationService, IntegrationService>();
builder.Services.AddScoped<IStorageBlobService, StorageBlobService>();
builder.Services.AddScoped<IHealthService, HealthService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IWebhookService, WebhookService>();
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();
builder.Services.AddScoped<IExportService, ExportService>();
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<IChecklistService, ChecklistService>();
builder.Services.AddScoped<IProcurementService, ProcurementService>();
builder.Services.AddScoped<IEventBusService, EventBusService>();
builder.Services.AddScoped<IRateLimitService, RateLimitService>();
builder.Services.AddScoped<IInjectionScanService, InjectionScanService>();

// Segments (10 new feature areas)
builder.Services.AddScoped<AERN.Api.Contracts.Segments.ICompliancePolicyService, AERN.Services.Segments.CompliancePolicyService>();
builder.Services.AddScoped<AERN.Api.Contracts.Segments.IPredictiveMaintenanceService, AERN.Services.Segments.PredictiveMaintenanceService>();
builder.Services.AddScoped<AERN.Api.Contracts.Segments.IVendorService, AERN.Services.Segments.VendorService>();
builder.Services.AddScoped<AERN.Api.Contracts.Segments.IEnergyConsumptionService, AERN.Services.Segments.EnergyConsumptionService>();
builder.Services.AddScoped<AERN.Api.Contracts.Segments.IShiftService, AERN.Services.Segments.ShiftService>();
builder.Services.AddScoped<AERN.Api.Contracts.Segments.IEscalationRuleService, AERN.Services.Segments.EscalationRuleService>();
builder.Services.AddScoped<AERN.Api.Contracts.Segments.IDocumentClassificationService, AERN.Services.Segments.DocumentClassificationService>();
builder.Services.AddScoped<AERN.Api.Contracts.Segments.IApiKeyService, AERN.Services.Segments.ApiKeyService>();
builder.Services.AddScoped<AERN.Api.Contracts.Segments.IRetentionPolicyService, AERN.Services.Segments.RetentionPolicyService>();
builder.Services.AddScoped<AERN.Api.Contracts.Segments.IFieldCheckInService, AERN.Services.Segments.FieldCheckInService>();

// JWT Authentication
var jwtKey = builder.Configuration["Jwt:Key"] ?? "AERN-Default-Key-Min-32-Chars-For-HS256!!";
var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? "AERN.Api";
var jwtAudience = builder.Configuration["Jwt:Audience"] ?? "AERN.Client";
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
            ClockSkew = TimeSpan.FromMinutes(1)
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddControllers();

// Swagger / OpenAPI with JWT support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AERN API",
        Version = "v1",
        Description = "AI-Driven Enterprise Resource Nexus – Industrial assets, telemetry, documents, multi-tenant API."
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        In = ParameterLocation.Header,
        Description = "JWT Bearer. Call POST /api/auth/login, copy the 'token' value, then click Authorize and enter: Bearer <token>"
    });
});

var app = builder.Build();

// Pipeline
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Swagger: enable in Development or when explicitly enabled (e.g. Staging)
var useSwagger = app.Environment.IsDevelopment() || string.Equals(app.Configuration["EnableSwagger"], "true", StringComparison.OrdinalIgnoreCase);
if (useSwagger)
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AERN API v1");
        c.DisplayRequestDuration();
        c.EnableTryItOutByDefault();
        c.DocumentTitle = "AERN API";
    });
}

app.MapControllers();

app.Run();
