CREATE PROCEDURE [dbo].[P_Barcode_Upsert](
@AnalyseId INT,
@TimeStamp datetime,
@ParserIOVersion NVARCHAR(MAX),
@Barcode NVARCHAR(MAX),
@SymbologyID NVARCHAR(MAX),
@SymbologyIDDesignation NVARCHAR(MAX),
@Type NVARCHAR(MAX),
@SubType NVARCHAR(MAX),
@ContainsOrMayContainId bit,
@Identifiers NVARCHAR(MAX),
@ACL NVARCHAR(MAX),
@ADDITIONALID NVARCHAR(MAX),
@CUSTPARTNO NVARCHAR(MAX),
@BESTBEFORE NVARCHAR(MAX),
@CIP NVARCHAR(MAX),
@CONTENT NVARCHAR(MAX),
@COUNT NVARCHAR(MAX),
@EAN NVARCHAR(MAX),
@Expiry NVARCHAR(MAX),
@Family NVARCHAR(MAX),
@GTIN NVARCHAR(MAX),
@INTERNAL_90 NVARCHAR(MAX),
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
@Quantity NVARCHAR(MAX),
@Reference NVARCHAR(MAX),
@Serial NVARCHAR(MAX),
@SSCC NVARCHAR(MAX),
@StorageLocation NVARCHAR(MAX),
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
		   ,[ParserIOVersion]
		   ,[Barcode]
		   ,[SymbologyID]
		   ,[SymbologyIDDesignation]
           ,[Type]
           ,[SubType]
           ,[ContainsOrMayContainId]
		   ,[Identifiers]
           ,[ACL]
           ,[ADDITIONALID]
		   ,[CUSTPARTNO]
           ,[BESTBEFORE]
           ,[CIP]
           ,[CONTENT]
           ,[COUNT]
		   ,[EAN]
           ,[Expiry]
           ,[Family]
           ,[GTIN]
		   ,[INTERNAL_90]
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
           ,[Quantity]
           ,[Reference]
           ,[Serial]
           ,[SSCC]
		   ,[StorageLocation]
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
			@ParserIOVersion,
		    @Barcode,
			@SymbologyID,
			@SymbologyIDDesignation,
            @Type,
            @SubType,
            @ContainsOrMayContainId,
			@Identifiers,
            @ACL,
            @ADDITIONALID,
			@CUSTPARTNO,
            @BESTBEFORE,
            @CIP,
            @CONTENT,
            @COUNT,
			@EAN,
            @Expiry,
            @Family,
            @GTIN,
			@INTERNAL_90,
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
            @Quantity,
            @Reference,
            @Serial,
            @SSCC,
			@StorageLocation,
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
       [ParserIOVersion] = @ParserIOVersion,
       [Type] = @Type,
       [SubType] = @SubType,
       [ContainsOrMayContainId] = @ContainsOrMayContainId,
	   [Identifiers] = @Identifiers,
       [ACL] = @ACL,
       [ADDITIONALID] = @ADDITIONALID,
	   [CUSTPARTNO] = @CUSTPARTNO,
       [BESTBEFORE] = @BESTBEFORE,
       [CIP] = @CIP,
       [CONTENT] = @CONTENT,
       [COUNT] = @COUNT,
       [Expiry] = @Expiry,
       [Family] = @Family,
       [GTIN] = @GTIN,
	   [INTERNAL_90] = @INTERNAL_90,
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
       [Quantity] = @Quantity,
       [Reference] = @Reference,
       [Serial] = @Serial,
       [SSCC] = @SSCC,
	   [StorageLocation]=@StorageLocation,
       [UDI] = @UDI,
       [UoM] = @UoM,
       [VARCOUNT] = @VARCOUNT,
       [VARIANT] = @VARIANT,
       [Commentary] = @Commentary,
       [SymbologyID] = @SymbologyID,
	   [SymbologyIDDesignation] = @SymbologyIDDesignation,
       [EAN] = @EAN,
       [NaSIdParamName] = @NaSIdParamName,
       [UPN] = @UPN,
       [AdditionalInformation] = @AdditionalInformation,
       [AnalyseId] = @AnalyseId,
       [TimeStamp] = @TimeStamp
 WHERE [AnalyseId]=@AnalyseId
END
END