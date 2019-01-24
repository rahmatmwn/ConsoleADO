CREATE TRIGGER kurangistok
	ON [dbo].[TransactionItems]
	FOR INSERT
	AS
	BEGIN
		UPDATE i set i.Quantity=i.Quantity-t.quantity
		FROM Items i join inserted t on
		i.id=t.items_id;
	END
