USE EFBook_DataAppDB

INSERT INTO Products (Name, Category, Price) VALUES
('?????????', '??????', 50),
('??????', '??????', 35),
('?????????', '??????', 55),
('????', '??????', 70),
('??????', '??????', 30),
('????????', '?????', 20),
('???????', '?????', 20),
('???????', '?????', 15),
('?????', '????????????? ???????', 10),
('??????', '????????????? ???????', 17),
('?????? ???????', '???????? ?????????', 33),
('??????', '???????? ?????????', 57)


SELECT ProductId, Name, Category, Price FROM Products