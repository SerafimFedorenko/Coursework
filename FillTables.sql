use recycling_point1
declare @NumberPositions int,
		@RowCount int,
		@Position varchar(30)
set nocount on

set @NumberPositions = 500
set @RowCount = 1

/*«аполнение таблицы должностей*/

while @RowCount < @NumberPositions
begin
	set @Position = concat('Position', ltrim(str(@RowCount)))
	insert into Positions(Name) 
	select @Position
	set @RowCount +=1
end

declare @NumberStorageTypes int,
		@StorageType varchar(30),
		@Temperature int,
		@Humidity int,
		@Requirement varchar(30),
		@Equipment varchar(30)

set @NumberStorageTypes = 500
set @RowCount = 1

/*«аполнение таблицы типов складских помещений*/

while @RowCount < @NumberStorageTypes
begin
	set @StorageType = concat('StorageType', ltrim(str(@RowCount)))
	set @Temperature = floor(rand() * 25)
	set @Humidity = floor(rand() * 60 + 10)
	set @Requirement = concat('Requirement', ltrim(str(floor(rand() * 25))))
	set @Equipment = concat('Equipment', ltrim(str(floor(rand() * 25))))
	insert into StorageTypes(Name, Temperature, Humidity, Requirement, Equipment) 
	select @StorageType, @Temperature, @Humidity, @Requirement, @Equipment
	set @RowCount +=1
end

declare @NumberRecyclableTypes int,
		@RecyclableType varchar(30),
		@Price decimal(18,3),
		@Description varchar(100),
		@AcceptanceCondition varchar(20),
		@StorageCondition varchar(20)

set @NumberRecyclableTypes = 500
set @RowCount = 1

/*«аполнение таблицы видов вторсырь€*/

while @RowCount < @NumberRecyclableTypes
begin
	set @RecyclableType = concat('RecyclableType', ltrim(str(@RowCount)))
	set @Price = rand() * 100 + 1
	set @Description = concat('Description', ltrim(str(floor(rand() * 25))))
	set @AcceptanceCondition = concat('AcceptCond', ltrim(str(floor(rand() * 25))))
	set @StorageCondition = concat('StorCond', ltrim(str(floor(rand() * 25))))
	insert into RecyclableTypes(Name, Price, Description, AcceptanceCondition, StorageCondition)
	select @RecyclableType, @Price, @Description, @AcceptanceCondition, @StorageCondition
	set @RowCount +=1
end

declare @NumberEmployees int,
		@EmployeeName varchar(30),
		@Surname varchar(30),
		@Patronymic varchar(30),
		@Experience int,
		@PositionId int

set @NumberEmployees = 20000
set @RowCount = 1

/*«аполнение таблицы сотрудников*/

while @RowCount < @NumberEmployees
begin
	set @EmployeeName = concat('Name', ltrim(str(floor(rand() * 50))))
	set @Surname = concat('Surname', ltrim(str(floor(rand() * 50))))
	set @Patronymic = concat('Patronymic', ltrim(str(floor(rand() * 50))))
	set @Experience = floor(rand() * 30)
	set @PositionId = floor(rand() * 499 + 1)
	insert into Employees(Name, Surname, Patronymic, Experience, PositionId)
	select @EmployeeName, @Surname, @Patronymic, @Experience, @PositionId
	set @RowCount +=1
end

declare @NumberStorages int,
		@StorageName varchar(30),
		@Number int,
		@Square int,
		@Capacity int,
		@Occupancy int,
		@Depreciation int,
		@CheckDate date,
		@StorageTypeId int

set @NumberStorages = 20000
set @RowCount = 1

/*«аполнение таблицы складских помещений*/

while @RowCount < @NumberStorages
begin
	set @StorageName = concat('Name', ltrim(str(@RowCount)))
	set @Number = @RowCount
	set @Square = floor(rand() * 865 + 15)
	set @Capacity = @Square * floor(rand() * 4 + 1)
	set @Occupancy = floor(@Capacity * rand())
	set @Depreciation = floor(rand() * 100)
	set @CheckDate = dateadd(day, floor(-rand() * 10000), getdate())
	set @StorageTypeId = floor(rand() * 499 + 1)
	insert into Storages(Name, Number, Square, Capacity, Occupancy, Depreciation, CheckDate, StorageTypeId)
	select @StorageName, @Number, @Square, @Capacity, @Occupancy, @Depreciation, @CheckDate, @StorageTypeId
	set @RowCount +=1
end

declare @NumberAcceeptedRec int,
		@EmployeeId int,
		@StorageId int,
		@RecyclebleTypeId int,
		@Quantity int,
		@Date date

set @NumberAcceeptedRec = 20000
set @RowCount = 1

/*«аполнение таблицы приходов сырь€*/

while @RowCount < @NumberAcceeptedRec
begin
	set @EmployeeId = floor(rand() * 19999 + 1)
	set @StorageId = floor(rand() * 19999 + 1)
	set @RecyclebleTypeId = floor(rand() * 499 + 1)
	set @Quantity = floor(rand() * 1999 + 1)
	set @Date = dateadd(day, floor(-rand() * 3650), getdate())
	insert into AcceptedRecyclables(EmployeeId, StorageId, RecyclableTypeId, Quantity, Date)
	select @EmployeeId, @StorageId, @RecyclebleTypeId, @Quantity, @Date
	set @RowCount +=1
end