# AERN API Segmentation

The API is organized into **core** and **segment** areas. Segments are feature verticals under `/api/segments/`.

## Core API (`/api/...`)

Existing areas: Tenants, Users, Roles, Passkeys, Assets, AssetTypes, AssetLocations, Telemetry, TelemetryAlerts, Documents, DocumentProcessing, Maintenance (WorkOrders, Schedules), Inventory (Parts, Stock), Reports, Notifications, AuditLogs, Configuration, Integrations, StorageBlobs, Health, Admin, Dashboards, Permissions, Sessions, Webhooks, Analytics, Export, Search, Checklists, Procurement, EventBus, RateLimit, InjectionScan, Auth, WeatherForecast.

---

## Segment API (`/api/segments/...`) – 10 New Points

| # | Segment | Route Prefix | Description |
|---|---------|--------------|-------------|
| 1 | **Compliance & Governance** | `/api/segments/compliance-policies` | Compliance policies, run checks, regulatory findings |
| 2 | **Predictive Maintenance** | `/api/segments/predictive-maintenance` | Asset risk, high-risk list, recommendations, prediction history |
| 3 | **Vendor & Supplier** | `/api/segments/vendors` | Vendor CRUD, contracts, supplier management |
| 4 | **Energy & Sustainability** | `/api/segments/energy` | Energy readings, summary, carbon footprint, ingest |
| 5 | **Workforce & Shifts** | `/api/segments/shifts` | Shift plans, assign users, user shift history |
| 6 | **Alerts & Escalation** | `/api/segments/escalation` | Escalation rules, evaluate/escalate, history |
| 7 | **Document AI / Classification** | `/api/segments/document-classification` | Classify documents, train categories, extract metadata |
| 8 | **API Keys & Clients** | `/api/segments/api-keys` | API keys, clients, revoke, rotate |
| 9 | **Data Retention & Archive** | `/api/segments/retention` | Retention policies, archive jobs, start job, job history |
| 10 | **Field / Mobile** | `/api/segments/field` | Field check-in/check-out, active check-in, offline sync, by location |

---

## Folder Structure (Segmentation)

- **Contracts:** `Api/Contracts/Segments/*.cs` – segment service interfaces and DTOs
- **Services:** `Services/Segments/*.cs` – segment service implementations
- **Controllers:** `Controllers/Segments/*.cs` – segment API controllers (all under `api/segments/...`)

All segment services are registered in `Program.cs` and follow the same patterns as the core API (ApiResult, PagedResult, IdResult, PagingRequest).
