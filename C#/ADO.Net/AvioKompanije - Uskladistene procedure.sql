USE AvioKompanija;
GO

CREATE PROC LetilicaSelect
AS
BEGIN
	SELECT * FROM Letilica;
END
GO

CREATE PROC LetilicaInsert
@regbr int, @tip nvarchar(20), @naziv nvarchar(50), @opis nvarchar(100)
AS
BEGIN
	INSERT INTO Letilica(RegBr,Tip,Naziv,Opis) VALUES (@regbr,@tip,@naziv,@opis);
END
GO

CREATE PROC LetilicaUpdate
@regbr int, @tip nvarchar(20), @naziv nvarchar(50), @opis nvarchar(100)
AS
BEGIN
	UPDATE Letilica SET Tip = @tip,Naziv = @naziv,Opis = @opis WHERE RegBr = @regbr; 
END
GO

CREATE PROC LetilicaDelete
@regbr int
AS
BEGIN
	DELETE Letilica WHERE RegBr = @regbr;
END
GO