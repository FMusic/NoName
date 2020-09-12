USE NoNameCoffeeBar;
GO

INSERT INTO UserType VALUES ('Admin');
INSERT INTO UserType VALUES ('Waiter');

INSERT INTO UserData VALUES ('milan', 'milan', 'Milan Siklic', 1);
INSERT INTO UserData VALUES ('pero', 'pero', 'Pero Peric', 2);

INSERT INTO Category VALUES ('Topli');
INSERT INTO Category VALUES ('Pivo');
INSERT INTO Category VALUES ('Gazirani');
INSERT INTO Category VALUES ('Zestoka');
INSERT INTO Category VALUES ('Vocni');

INSERT INTO Product VALUES ('Kava', 10, 8, 1);
INSERT INTO Product VALUES ('Cappucino', 10, 12, 1);
INSERT INTO Product VALUES ('Caj', 10, 10, 1);
INSERT INTO Product VALUES ('Ozujsko', 10, 12, 2);
INSERT INTO Product VALUES ('Karlovacko', 10, 14, 2);
INSERT INTO Product VALUES ('Corona', 10, 15, 2);
INSERT INTO Product VALUES ('Jamnica Sensation', 10, 10, 3);
INSERT INTO Product VALUES ('Coca-Cola', 10, 15, 3);
INSERT INTO Product VALUES ('Sprite', 10, 15, 3);
INSERT INTO Product VALUES ('Rakija', 10, 15, 4);
INSERT INTO Product VALUES ('Jack Daniels', 10, 10, 4);
INSERT INTO Product VALUES ('Pago', 10, 12, 5);
INSERT INTO Product VALUES ('Cappy', 10, 13, 5);

INSERT INTO Bill VALUES ('2020-06-24-0001');
INSERT INTO Bill VALUES ('2020-06-24-0002');
INSERT INTO Bill VALUES ('2020-06-24-0003');
INSERT INTO Bill VALUES ('2020-06-24-0004');

INSERT INTO BillContent VALUES (2,  8, 1, 1);
INSERT INTO BillContent VALUES (15, 2, 6, 1);
INSERT INTO BillContent VALUES (12, 3, 12, 2);
INSERT INTO BillContent VALUES (15, 4, 8, 2);
INSERT INTO BillContent VALUES (10, 5, 7, 2);
INSERT INTO BillContent VALUES (10, 6, 10, 3);
INSERT INTO BillContent VALUES (12, 7, 2, 4);
INSERT INTO BillContent VALUES (10, 8, 3, 4);

INSERT INTO BillStatus VALUES ('CREATED', '2020-06-24 16:27:05', 1);
INSERT INTO BillStatus VALUES ('APPROVED', '2020-06-24 16:28:20', 1);
INSERT INTO BillStatus VALUES ('PAYED', '2020-06-24 17:00:00', 1);
INSERT INTO BillStatus VALUES ('CREATED', '2020-06-24 15:00:00', 2);
INSERT INTO BillStatus VALUES ('CREATED', '2020-06-24 16:00:00', 3);
INSERT INTO BillStatus VALUES ('APPROVED', '2020-06-24 16:01:12', 3);
INSERT INTO BillStatus VALUES ('CREATED', '2020-06-24 08:15:00', 4);
INSERT INTO BillStatus VALUES ('REJECTED', '2020-06-24 08:15:01', 4);

INSERT INTO FileData VALUES ('BillReport_A.txt', '2020-06-24 12:00:00', 'text/plain', 'Ovo je bill-izvjestaj A.');
INSERT INTO FileData VALUES ('BillReport_B.txt', '2020-06-25 00:00:00', 'text/plain', 'Ovo je bill-izvjestaj B.');
INSERT INTO FileData VALUES ('SupplyReport_A.txt', '2020-06-23 00:00:00', 'text/plain', 'Ovo je supply-izvjestaj A.');
INSERT INTO FileData VALUES ('SupplyReport_B.txt', '2020-06-24 00:00:00', 'text/plain', 'Ovo je supply-izvjestaj B.');

INSERT INTO BillReport VALUES (2020, 6, 24, 1);
INSERT INTO BillReport VALUES (2020, 6, 25, 2);

INSERT INTO SupplyReport VALUES (2020, 6, 23, 3);
INSERT INTO SupplyReport VALUES (2020, 6, 24, 4);
