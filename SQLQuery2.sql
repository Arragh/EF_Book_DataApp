USE EFBook_DataAppDB

SELECT column_name, data_type FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Products'

GO