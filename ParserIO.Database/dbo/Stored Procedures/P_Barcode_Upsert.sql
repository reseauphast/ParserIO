CREATE PROCEDURE [dbo].[P_Barcode_Upsert](
@AnalyseId INT,
@TimeStamp datetime,
@Barcode NVARCHAR(MAX),
@SymbologyID NVARCHAR(MAX),
@Type NVARCHAR(MAX),
@SubType NVARCHAR(MAX),
@ContainsOrMayContainId bit,
@ACL NVARCHAR(MAX),
@ADDITIONALID NVARCHAR(MAX),
@BESTBEFORE NVARCHAR(MAX),
@CIP NVARCHAR(MAX),
@Company NVARCHAR(MAX),
@CONTENT NVARCHAR(MAX),
@COUNT NVARCHAR(MAX),
@EAN NVARCHAR(MAX),
@Expiry NVARCHAR(MAX),
@Family NVARCHAR(MAX),
@GTIN NVARCHAR(MAX),
@INTERNAL_91 NVARCHAR(MAX),
@INTERNAL_92 NVARCHAR(MAX),
@INTERNAL_93 NVARCHAR(MAX),
@INTERNAL_94 NVARCHAR(MAX),
@INTERNAL_95 NVARCHAR(MAX),
@INTERNAL_96 NVARCHAR(MAX),
@INTERNAL_97 NVARCHAR(MAX),
@INTERNAL_98 NVARCHAR(MAX),
@INTERNAL_99 NVARCHAR(MAX),
@LIC NVARCHAR(MAX),
@Lot NVARCHAR(MAX),
@LPP NVARCHAR(MAX),
@NaS7 NVARCHAR(MAX),
@NaSIdParamName NVARCHAR(MAX),
@NormalizedBESTBEFORE NVARCHAR(MAX),
@NormalizedExpiry NVARCHAR(MAX),
@NormalizedPRODDATE NVARCHAR(MAX),
@PCN NVARCHAR(MAX),
@PRODDATE NVARCHAR(MAX),
@Product NVARCHAR(MAX),
@Quantity NVARCHAR(MAX),
@Reference NVARCHAR(MAX),
@Serial NVARCHAR(MAX),
@SSCC NVARCHAR(MAX),
@UDI NVARCHAR(MAX),
@UoM NVARCHAR(MAX),
@UPN NVARCHAR(MAX),
@VARCOUNT NVARCHAR(MAX),
@VARIANT NVARCHAR(MAX),
@AdditionalInformation nvarchar(MAX),
@Commentary NVARCHAR(MAX)
)
AS
BEGIN
SELECT * FROM [BarcodesStore]
WHERE [AnalyseId]=@AnalyseId
IF @@ROWCOUNT = 0
BEGIN
INSERT INTO [dbo].[BarcodesStore]
           ([AnalyseId]
		   ,[TimeStamp]
		   ,[Barcode]
		   ,[SymbologyID]
           ,[Type]
           ,[SubType]
           ,[ContainsOrMayContainId]
           ,[ACL]
           ,[ADDITIONALID]
           ,[BESTBEFORE]
           ,[CIP]
           ,[Company]
           ,[CONTENT]
           ,[COUNT]
		   ,[EAN]
           ,[Expiry]
           ,[Family]
           ,[GTIN]
		   ,[INTERNAL_91]
		   ,[INTERNAL_92]
           ,[INTERNAL_93]
		   ,[INTERNAL_94]
		   ,[INTERNAL_95]
		   ,[INTERNAL_96]
		   ,[INTERNAL_97]
		   ,[INTERNAL_98]
		   ,[INTERNAL_99]
           ,[LIC]
           ,[Lot]
           ,[LPP]
           ,[NaS7]
		   ,[NaSIdParamName]
           ,[NormalizedBESTBEFORE]
           ,[NormalizedExpiry]
           ,[NormalizedPRODDATE]
           ,[PCN]
           ,[PRODDATE]
           ,[Product]
           ,[Quantity]
           ,[Reference]
           ,[Serial]
           ,[SSCC]
           ,[UDI]
           ,[UoM]
		   ,[UPN]
           ,[VARCOUNT]
           ,[VARIANT]
		   ,[AdditionalInformation]
           ,[Commentary])
     VALUES
           (@AnalyseId,
		    @TimeStamp,
		    @Barcode,
			@SymbologyID,
            @Type,
            @SubType,
            @ContainsOrMayContainId,
            @ACL,
            @ADDITIONALID,
            @BESTBEFORE,
            @CIP,
            @Company,
            @CONTENT,
            @COUNT,
			@EAN,
            @Expiry,
            @Family,
            @GTIN,
			@INTERNAL_91,
			@INTERNAL_92,
			@INTERNAL_93,
			@INTERNAL_94,
			@INTERNAL_95,
			@INTERNAL_96,
			@INTERNAL_97,
			@INTERNAL_98,
			@INTERNAL_99,
            @LIC,
            @Lot,
            @LPP,
            @NaS7,
			@NaSIdParamName,
            @NormalizedBESTBEFORE,
            @NormalizedExpiry,
            @NormalizedPRODDATE,
            @PCN,
            @PRODDATE,
            @Product,
            @Quantity,
            @Reference,
            @Serial,
            @SSCC,
            @UDI,
            @UoM,
			@UPN,
            @VARCOUNT,
            @VARIANT,
			@AdditionalInformation,
            @Commentary)
END
ELSE
BEGIN
UPDATE [dbo].[BarcodesStore]
   SET [Barcode] = @Barcode,
       [Type] = @Type,
       [SubType] = @SubType,
       [ContainsOrMayContainId] = @ContainsOrMayContainId,
       [ACL] = @ACL,
       [ADDITIONALID] = @ADDITIONALID,
       [BESTBEFORE] = @BESTBEFORE,
       [CIP] = @CIP,
       [Company] = @Company,
       [CONTENT] = @CONTENT,
       [COUNT] = @COUNT,
       [Expiry] = @Expiry,
       [Family] = @Family,
       [GTIN] = @GTIN,
	   [INTERNAL_91] = @INTERNAL_91,
	   [INTERNAL_92] = @INTERNAL_92,
	   [INTERNAL_93] = @INTERNAL_93,
	   [INTERNAL_94] = @INTERNAL_94,
	   [INTERNAL_95] = @INTERNAL_95,
	   [INTERNAL_96] = @INTERNAL_96,
	   [INTERNAL_97] = @INTERNAL_97,
	   [INTERNAL_98] = @INTERNAL_98,
	   [INTERNAL_99] = @INTERNAL_99,
       [LIC] = @LIC,
       [Lot] = @Lot,
       [LPP] = @LPP,
       [NaS7] = @NaS7,
       [NormalizedBESTBEFORE] = @NormalizedBESTBEFORE,
       [NormalizedExpiry] = @NormalizedExpiry,
       [NormalizedPRODDATE] = @NormalizedPRODDATE,
       [PCN] = @PCN,
       [PRODDATE] = @PRODDATE,
       [Product] = @Product,
       [Quantity] = @Quantity,
       [Reference] = @Reference,
       [Serial] = @Serial,
       [SSCC] = @SSCC,
       [UDI] = @UDI,
       [UoM] = @UoM,
       [VARCOUNT] = @VARCOUNT,
       [VARIANT] = @VARIANT,
       [Commentary] = @Commentary,
       [SymbologyID] = @SymbologyID,
       [EAN] = @EAN,
       [NaSIdParamName] = @NaSIdParamName,
       [UPN] = @UPN,
       [AdditionalInformation] = @AdditionalInformation,
       [AnalyseId] = @AnalyseId,
       [TimeStamp] = @TimeStamp
 WHERE [AnalyseId]=@AnalyseId
END
END