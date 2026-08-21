# Database Investigation (DATABASE.md)

## Discovered Tables and Key Structures

### 1. Departments
- **Primary Key:** `Id` (INTEGER, Autoincrement)
- **Nullable Columns:** `Description` (TEXT)
- **Relationships:** One-to-Many with `Employees` and `Teams`.

### 2. Employees
- **Primary Key:** `Id` (INTEGER, Autoincrement)
- **Foreign Keys:** `DepartmentId` -> `Departments(Id)`
- **Relationships:** Many-to-One with `Departments`, Many-to-Many with `Teams` via `TeamMembers`, Many-to-Many with `Tickets` via `TicketAssignments`.

### 3. Teams
- **Primary Key:** `Id` (INTEGER, Autoincrement)
- **Foreign Keys:** `DepartmentId` -> `Departments(Id)`
- **Unique Constraint:** `(DepartmentId, Name)`

### 4. TeamMembers
- **Composite Primary Key:** `(TeamId, EmployeeId)`
- **Foreign Keys:** `TeamId` -> `Teams(Id)`, `EmployeeId` -> `Employees(Id)`

### 5. Customers
- **Primary Key:** `Id` (INTEGER, Autoincrement)
- **Nullable Columns:** `Phone` (TEXT)

### 6. TicketPriorities & TicketStatuses
- **Primary Key:** `Id` (INTEGER, Autoincrement)
- **Unique Columns:** `Name`

### 7. TicketCategories
- **Primary Key:** `Id` (INTEGER, Autoincrement)
- **Self-Referencing Foreign Key:** `ParentCategoryId` -> `TicketCategories(Id)` (Nullable)

### 8. Tickets
- **Primary Key:** `Id` (INTEGER, Autoincrement)
- **Foreign Keys:** `CustomerId`, `CategoryId`, `PriorityId`, `StatusId`
- **Nullable Columns:** `DueAt`, `ResolvedAt`, `ClosedAt`

### 9. TicketAssignments
- **Composite Primary Key:** `(TicketId, EmployeeId)`
- **Nullable Columns:** `UnassignedAt`
- **Payload Columns:** `IsPrimary` (INTEGER DEFAULT 0), `AssignedAt`

### 10. TicketComments
- **Primary Key:** `Id` (INTEGER, Autoincrement)
- **Foreign Keys:** `TicketId`, `EmployeeId` (Nullable)

### 11. TicketAttachments
- **Primary Key:** `Id` (INTEGER, Autoincrement)
- **Foreign Keys:** `TicketId`

### 12. Tags & TicketTags
- **Composite Primary Key:** `(TicketId, TagId)` in `TicketTags`.
