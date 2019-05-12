use ShopDB;

merge into dbo.Goods as [target]
using (
	values 
	('Iphone 5s', '~/Content/Images/Iphone 5s.jpeg', 'Apple', 9999),
	('Huawei Mate P20', '~/Content/Images/Huawei Mate P20.png', 'Huawei', 30000),
	('Iphone Xs', '~/Content/Images/Iphone Xs.jpeg', 'Apple', 45000),
	('Samsung S10', '~/Content/Images/Samsung S10.jpg', 'Samsung', 35000),
	('iPhone XS Max Dual Sim 512GB', '~/Content/Images/iPhone XS Max Dual Sim 512GB.jpg', 'Apple', 54982),
	('Samsung Galaxy S10 Plus 12GB/1TB', '~/Content/Images/Samsung Galaxy S10 Plus 12GB_1TB.jpg', 'Samsung', 51999),
	('Huawei P30 Pro 8/256GB', '~/Content/Images/Huawei P30 Pro 8_256GB.jpg', 'Huawei', 32999),
	('Huawei P smart', '~/Content/Images/Huawei P smart.jpg', 'Huawei', 6999)
) as [source](GoodName, ImagePath, Manufacturer, Price)
on target.Name = source.GoodName
when matched then update set price = source.price
when not matched  then insert (Name, ImagePath, Manufacturer, Price) values(GoodName, ImagePath, Manufacturer, Price);