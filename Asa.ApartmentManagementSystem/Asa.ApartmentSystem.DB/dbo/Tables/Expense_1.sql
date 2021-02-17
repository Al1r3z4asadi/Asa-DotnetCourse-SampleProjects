CREATE TABLE [dbo].[Expense] (
    [id]              INT           IDENTITY (1, 1) NOT NULL,
    [title]            NVARCHAR (50) NOT NULL,
    [category_id] int     NOT NULL,
    [from]      DATETIME NOT NULL,
    [to]        DATETIME NULL,
    [cost]      decimal(10,10),
    CONSTRAINT [PK_Expense] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Expense_Category] FOREIGN KEY ([category_id]) REFERENCES [dbo].[Category]([id])
);