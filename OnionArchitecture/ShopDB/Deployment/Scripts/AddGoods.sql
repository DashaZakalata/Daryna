use ShopDB;

merge into dbo.Goods as [target]
using (
	values 
	('Iphone 5s', 9999),
	('Huawaii Mate P20', 30000),
	('Iphone Xs', 45000),
	('Samsung S10', 35000)
) as [source](GoodName, Price)
on target.Name = source.GoodName
when matched then update set price = source.price
when not matched  then insert (Name, Price) values(GoodName, Price);