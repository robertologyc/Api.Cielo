namespace Api.Cielo.Lio.Domain.Enums
{
    /// <summary>
    ///     Retorna o código da mensagem enviada pela API Cielo
    /// </summary>
    public enum ReturnCodeEnumerator
    {
        /// <summary>
        ///     Erro interno da API.Cielo.Lio
        /// </summary>
        ApiInternalError = -1,
        
        /// <summary>
        ///     Erro interno da API Cielo
        /// </summary>
        InternalError = 0,
        
        /// <summary>
        ///     Operação Realizada com Sucesso 
        /// </summary>
        OperationSuccessfully = 4,

        /// <summary>
        ///     Operação Realizada com Sucesso 
        /// </summary>
        OperationSuccessfully2 = 6,

        /// <summary>
        ///     Operação Não Autorizada
        /// </summary>
        NotAuthorized = 5,

        /// <summary>
        ///     Cartão expirado
        /// </summary>
        ExpiredCard = 57,

        /// <summary>
        ///     Cartão bloqueado
        /// </summary>
        LockedCard = 78,

        /// <summary>
        ///     Cartão cancelado
        /// </summary>
        CanceledCard = 77,

        /// <summary>
        ///     Problema com o cartão de crédito
        /// </summary>
        ProblemsWithTheCreditCard = 70,

        /// <summary>
        ///     Tempo excedido
        /// </summary>
        TimeOut = 99,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        RequestIdIsRequired = 100,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        MerchantIdIsRequired = 101,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        PaymentTypeIsRequired = 102,

        /// <summary>
        ///     Caracteres especiais não permitidos
        /// </summary>
        PaymentTypeCanOnlyContainLetters = 103,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        CustomerIdentityIsRequired = 104,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        CustomerNameIsRequired = 105,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        TransactionIdIsRequired = 106,

        /// <summary>
        ///     Campo enviado excede o tamanho ou contem caracteres especiais
        /// </summary>
        OrderIdIsInvalidOrDoesNotExists = 107,

        /// <summary>
        ///     Valor da transação deve ser maior que “0”
        /// </summary>
        AmountMustBeGreaterOrEqualToZero = 108,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        PaymentCurrencyIsRequired = 109,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        InvalidPaymentCurrency = 110,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        PaymentCountryIsRequired = 111,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        InvalidPaymentCountry = 112,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        InvalidPaymentCode = 113,

        /// <summary>
        ///     O MerchantId enviado não é um GUID
        /// </summary>
        TheProvidedMerchantIdIsNotInCorrectFormat = 114,

        /// <summary>
        ///     O MerchantID não existe ou pertence a outro ambiente (EX: Sandbox)
        /// </summary>
        TheProvidedMerchantIdWasNotFound = 115,

        /// <summary>
        ///     Loja bloqueada, entre em contato com o suporte Cielo
        /// </summary>
        TheProvidedMerchantIdIsBlocked = 116,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        CreditCardHolderIsRequired = 117,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        CreditCardNumberIsRequired = 118,

        /// <summary>
        ///     Nó “Payment” não enviado
        /// </summary>
        AtLeastOnePaymentIsRequired = 119,

        /// <summary>
        ///     IP bloqueado por questões de segurança
        /// </summary>
        RequestIpNotAllowedCheckYourIpWhiteList = 120,

        /// <summary>
        ///     Nó “Customer” não enviado
        /// </summary>
        CustomerIsRequired = 121,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        MerchantOrderIdIsRequired = 122,

        /// <summary>
        ///     Numero de parcelas deve ser superior a 1
        /// </summary>
        InstallmentsMustBeGreaterOrEqualToOne = 123,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        CreditCardIsRequired = 124,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        CreditCardExpirationDateIsRequired = 125,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        CreditCardExpirationDateIsInvalid = 126,

        /// <summary>
        ///     Numero do cartão de crédito é obrigatório
        /// </summary>
        YouMustProvideCreditcardNumber = 127,

        /// <summary>
        ///     Numero do cartão superiro a 16 digitos
        /// </summary>
        CardNumberLengthExceeded = 128,

        /// <summary>
        ///     Meio de pagamento não vinculado a loja ou Provider invalido
        /// </summary>
        AffiliationNotFound = 129,

        /// <summary>
        ///     Não pode recuperar o credit card
        /// </summary>
        CouldNotGetCreditCard = 130,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        MerchantKeyIsRequired = 131,

        /// <summary>
        ///     O Merchantkey enviado não é um válido
        /// </summary>
        MerchantKeyIsInvalid = 132,

        /// <summary>
        ///     Provider enviado não existe
        /// </summary>
        ProviderIsNotSupportedForThisPaymentType = 133,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        FingerprintLengthExceeded = 134,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        MerchantDefinedFieldValueLengthExceeded = 135,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        ItemDataNameLengthExceeded = 136,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        ItemDataSkuLengthExceeded = 137,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        PassengerDataNameLengthExceeded = 138,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        PassengerDataStatusLengthExceeded = 139,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        PassengerDataEmailLengthExceeded = 140,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        PassengerDataPhoneLengthExceeded = 141,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        TravelDataRouteLengthExceeded = 142,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        TravelDataJourneyTypeLengthExceeded = 143,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        TravellegDataDestinationLengthExceeded = 144,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        TravellegDataOriginLengthExceeded = 145,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        SecurityCodeLengthExceeded = 146,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        AddressStreetLengthExceeded = 147,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        AddressNumberLengthExceeded = 148,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        AddressComplementLengthExceeded = 149,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        AddressZipcodeLengthExceeded = 150,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        AddressCityLengthExceeded = 151,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        AddressStateLengthExceeded = 152,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        AddressCountryLengthExceeded = 153,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        AddressDistrictLengthExceeded = 154,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        CustomerNameLengthExceeded = 155,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        CustomerIdentityLengthExceeded = 156,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        CustomerIdentitytypeLengthExceeded = 157,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        CustomerEmailLengthExceeded = 158,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        ExtraDataNameLengthExceeded = 159,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        ExtraDataValueLengthExceeded = 160,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        BoletoInstructionsLengthExceeded = 161,

        /// <summary>
        ///     Dado enviado excede o tamanho do campo
        /// </summary>
        BoletoDemostrativeLengthExceeded = 162,

        /// <summary>
        ///     URL de retorno não é valida - Não é aceito paginação ou extenções (EX .PHP) na URL de retorno
        /// </summary>
        ReturnUrlIsRequired = 163,

        /// <summary>
        ///     Autorização é requerida
        /// </summary>
        AuthorizeNowIsRequired = 166,

        /// <summary>
        ///     Antifraude não vinculado ao cadastro do lojista
        /// </summary>
        AntiFraudNotConfigured = 167,

        /// <summary>
        ///     Recorrencia não encontrada
        /// </summary>
        RecurrentPaymentNotFound = 168,

        /// <summary>
        ///     Recorrencia não está ativa. Execução paralizada
        /// </summary>
        RecurrentPaymentIsNotActive = 169,

        /// <summary>
        ///     Cartão protegido não vinculado ao cadastro do lojista
        /// </summary>
        CartaoProtegidoNotConfigured = 170,

        /// <summary>
        ///     Falha no processamento do pedido - Entre em contato com o suporte Cielo
        /// </summary>
        AffiliationDataNotSent = 171,

        /// <summary>
        ///     Falha na validação das credenciadas enviadas
        /// </summary>
        CredentialCodeIsRequired = 172,

        /// <summary>
        ///     Meio de pagamento não vinculado ao cadastro do lojista
        /// </summary>
        PaymentMethodIsNotEnabled = 173,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        CardNumberIsRequired = 174,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        EanIsRequired = 175,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        PaymentCurrencyIsNotSupported = 176,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        CardNumberIsInvalid = 177,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        EanIsInvalid = 178,

        /// <summary>
        ///     Campo enviado está vazio ou invalido
        /// </summary>
        TheMaxNumberOfInstallmentsAllowedForRecurringPaymentIs1 = 179,

        /// <summary>
        ///     Token do Cartão protegido não encontrado
        /// </summary>
        TheProvidedCardPaymenttokenWasNotFound = 180,

        /// <summary>
        ///     Token do Cartão protegido bloqueado
        /// </summary>
        TheMerchantIdJustClickIsNotConfigured = 181,

        /// <summary>
        ///     Bandeira do cartão não enviado
        /// </summary>
        BrandIsRequired = 182,

        /// <summary>
        ///     Data de nascimento invalida ou futura
        /// </summary>
        InvalidCustomerBithdate = 183,

        /// <summary>
        ///     Falha no formado ta requisição. Verifique o código enviado
        /// </summary>
        RequestCouldNotBeEmpty = 184,

        /// <summary>
        ///     Bandeira não suportada pela API Cielo
        /// </summary>
        BrandIsNotSupportedBySelectedProvider = 185,

        /// <summary>
        ///     Meio de pagamento não suporta o comando enviado
        /// </summary>
        TheSelectedProviderDoesNotSupportTheOptionsProvided = 186,

        /// <summary>
        ///     Contém nomes duplicados
        /// </summary>
        ExtraDataCollectionContainsOneOrMoreDuplicatedNames = 187,
        /// <summary>
        ///     Não autorizada
        /// </summary>
        KA
    }
}
