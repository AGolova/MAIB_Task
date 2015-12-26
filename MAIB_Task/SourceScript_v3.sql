/*CREATE PROCEDURE MAIB_Task MAIN PROCEDURE*/
CREATE PROCEDURE MAIB_Task
	@TableName	NVARCHAR(255)
AS
BEGIN

/*===================================================================
DB objects check start
=====================================================================*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'U' AND name = @TableName)
	BEGIN
		/* START
		создание временной таблицы данных файла*/
		/*TABLE NAME TransactionTest FOR DATA INSERTING*/
		CREATE TABLE TransactionTest  (
			[ID_plata] [nvarchar](255) NOT NULL PRIMARY KEY CLUSTERED,
			[Date_Time] [nvarchar] (50) NOT NULL,
			[payment_type] [nvarchar](5) NOT NULL,
			[amount] [decimal](20, 5) NOT NULL,
			[currency] [int] NOT NULL,
			[language] [nvarchar](5) NULL,
			[receiverID] [int] NOT NULL,
			[result] [nvarchar](50) NULL,
			[result_code] [int] NULL,
			[ID_F] [bigint] NULL,
			[CONFIRMATION_code] [nvarchar](50) NULL,
			[hash] [nvarchar](255) NOT NULL)
		/* END*/
	END
/*===================================================================
Reports block start
=====================================================================*/
ELSE
	BEGIN
		/* START 
		variables and values for formatting data in output files*/
		DECLARE 
				@Txt						NVARCHAR(MAX)	= NULL
				,@receiverID				INT				= NULL
				,@amount					DECIMAL(20,5)	= NULL
				,@TableHeader				NVARCHAR(MAX)	= NULL
				,@TableHeader2				NVARCHAR(MAX)	= NULL
				,@TableFooter				NVARCHAR(MAX)	= NULL
				,@ReportName				NVARCHAR(MAX)	= NULL
				,@TableColumns				NVARCHAR(MAX)	= NULL
				,@Step						INT				= 0
				,@reusite					NVARCHAR(255)	= NULL
				,@refuzate					NVARCHAR(255)	= NULL

		SET @TableHeader=N'<html><head><meta charset=utf-8></head>
			<p><span style="font-size:18px"><strong>'
		SET @TableHeader2 =N'</span></p>
		<table border="1" cellpadding="1" cellspacing="1">
			<tbody>'
		SET @TableFooter ='
			</tbody>
		</table>
		</html>'
		/* END */

			SET @ReportName = N'Сумма оплат по каждому получателю'
			SET @TableColumns = N'
					<tr><td>receiverID</td><td>amount</td></tr>'
			SET @Txt = @TableHeader + @ReportName + @TableHeader2+@TableColumns
			DECLARE curReport1 CURSOR FORWARD_ONLY READ_ONLY 
				FOR 
					SELECT 
						[receiverID],
						SUM([amount]) AS [amount]
					FROM TransactionTest
					GROUP BY [receiverID]
			OPEN curReport1
			FETCH NEXT FROM curReport1 INTO @receiverID,@amount
			WHILE @@FETCH_STATUS = 0
				BEGIN
					SET @Txt = 
						@Txt + N'
					<tr>'
						+ N'<td>'+CAST(@receiverID AS NVARCHAR(255))+N'</td>'
						+ N'<td>'+CAST(@amount AS NVARCHAR(255))+N'</td>'
						+ N'</tr>'
					FETCH NEXT FROM curReport1 INTO @receiverID,@amount
				END
			CLOSE curReport1
			DEALLOCATE curReport1
			SET @Txt = @Txt + @TableFooter
			SELECT @Txt AS Report1
			
			/* Успешность транзакции определялись этим:
			SELECT 
				[result],
				result_code
			FROM TransactionTest
			group by [result],result_code*/
			SET @ReportName = N'Сумма оплат по каждому получателю с успешной и неуспешной транзакцией'
			SET @TableColumns = N'
					<tr><td>receiverID</td><td>reusite</td><td>refuzate</td></tr>'
			SET @Txt = @TableHeader + @ReportName + @TableHeader2+@TableColumns

			DECLARE curReport2 CURSOR FORWARD_ONLY READ_ONLY 
				FOR 
					SELECT 
						[receiverID]
						,	(SELECT SUM([amount]) FROM TransactionTest AS ttReus 
							WHERE tt1.[receiverID] = ttReus.[receiverID] 
							AND [result_code] = 0) 
						AS [reusite]
						,	(SELECT SUM([amount]) FROM TransactionTest AS ttRef 
							WHERE tt1.[receiverID] = ttRef.[receiverID] 
							AND [result_code] <> 0) 
						AS [refuzate]
					FROM TransactionTest AS tt1
					GROUP BY [receiverID]
			OPEN curReport2
			FETCH NEXT FROM curReport2 INTO @receiverID,@reusite,@refuzate
			WHILE @@FETCH_STATUS = 0
				BEGIN
					SET @Txt = 
						@Txt + N'
					<tr>'
						+ N'<td>'+CAST(@receiverID AS NVARCHAR(255))+N'</td>'
						+ N'<td>'+CAST(ISNULL(@reusite,'') AS NVARCHAR(255))+N'</td>'
						+ N'<td>'+CAST(ISNULL(@refuzate,'') AS NVARCHAR(255))+N'</td>'
						+ N'</tr>'
					FETCH NEXT FROM curReport2 INTO @receiverID,@reusite,@refuzate
				END
			CLOSE curReport2
			DEALLOCATE curReport2
			SET @Txt = @Txt + @TableFooter
			SELECT @Txt AS Report2

			SET @ReportName = N'Сумма оплат по каждому получателю с успешной и неуспешной транзакцией2'
			SET @TableColumns = N'
					<tr><td>receiverID</td><td>reusite</td><td>refuzate</td><td>cantitate</td></tr>'
			SET @Txt = @TableHeader + @ReportName + @TableHeader2+@TableColumns
			DECLARE @Cantitate	NVARCHAR(255) = NULL
			DECLARE curReport3 CURSOR FORWARD_ONLY READ_ONLY 
				FOR 
					SELECT 
						[receiverID]
						,	(SELECT SUM([amount]) FROM TransactionTest AS ttReus 
							WHERE tt1.[receiverID] = ttReus.[receiverID] 
							AND [result_code] = 0) 
						AS [reusite]
						,	(SELECT SUM([amount]) FROM TransactionTest AS ttRef 
							WHERE tt1.[receiverID] = ttRef.[receiverID] 
							AND [result_code] <> 0) 
						AS [refuzate]
						,COUNT([ID_plata]) AS cantitate
					FROM TransactionTest AS tt1
			GROUP BY [receiverID]
			HAVING COUNT([ID_plata]) > 2
			OPEN curReport3
			FETCH NEXT FROM curReport3 INTO @receiverID,@reusite,@refuzate,@Cantitate
			WHILE @@FETCH_STATUS = 0
				BEGIN
					SET @Txt = 
						@Txt + N'
					<tr>'
						+ N'<td>'+CAST(@receiverID AS NVARCHAR(255))+N'</td>'
						+ N'<td>'+CAST(ISNULL(@reusite,'') AS NVARCHAR(255))+N'</td>'
						+ N'<td>'+CAST(ISNULL(@refuzate,'') AS NVARCHAR(255))+N'</td>'
						+ N'<td>'+CAST(ISNULL(@Cantitate,'') AS NVARCHAR(255))+N'</td>'
						+ N'</tr>'
					FETCH NEXT FROM curReport3 INTO @receiverID,@reusite,@refuzate,@Cantitate
				END
			CLOSE curReport3
			DEALLOCATE curReport3
			SET @Txt = @Txt + @TableFooter
			SELECT @Txt AS Report3
	END -- ELSE
END -- PROCEDURE