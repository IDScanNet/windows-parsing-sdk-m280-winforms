namespace CompiledTechnologies.Files
{
    public class DLFILE
    {
        #region *********************************** Private Fields ****************************************
        private readonly DLRECORD rec;
        #endregion

        #region ******************************* Public Initialization *************************************
        public DLFILE()
        {
            rec = new DLRECORD();
        }
        #endregion

        #region ********************************* Public Properties ***************************************
        public DLRECORD Record
        {
            get { return rec; }
        }
        #endregion

        public class DLRECORD
        {
            #region *********************************** Private Fields ****************************************
            string address1;
            string address2;
            string birthdate;
            string cardrevisiondate;
            string city;
            string classificationcode;
            string compliancetype;
            string country;
            string documenttype;
            string endorsementcodedescription;
            string endorsementscode;
            string exceptionmessage;
            string expirationdate;
            string eyecolor;
            string firstname;
            string fullname;
            string gender;
            string haircolor;
            string hazmatexpdate;
            string height;
            string iin;
            string issuedate;
            string issuedby;
            string jurisdictioncode;
            string lastname;
            string licensenumber;
            string limiteddurationdocument;
            string middlename;
            string nameprefix;
            string namesuffix;
            string organdonor;
            string postalcode;
            string race;
            string restrictioncode;
            string restrictioncodedescription;
            string specification;
            string vehicleclasscode;
            string vehicleclasscodedescription;
            string veteran;
            string weightkg;
            string weightlbs;
            #endregion

            #region ********************************* Public Initialize ***************************************
            public DLRECORD()
            {
                Initialize();
            }
            #endregion

            #region ********************************* Public Properties ***************************************
            public string Address1
            {
                get { return address1; }
                set { address1 = value; }
            }
            public string Address2
            {
                get { return address2; }
                set { address2 = value; }
            }
            public string Birthdate
            {
                get { return birthdate; }
                set { birthdate = value; }
            }
            public string CardRevisionDate
            {
                get { return cardrevisiondate; }
                set { cardrevisiondate = value; }
            }
            public string City
            {
                get { return city; }
                set { city = value; }
            }
            public string ClassificationCode
            {
                get { return classificationcode; }
                set { classificationcode = value; }
            }
            public string ComplianceType
            {
                get { return compliancetype; }
                set { compliancetype = value; }
            }
            public string Country
            {
                get { return country; }
                set { country = value; }
            }
            public string DocumentType
            {
                get { return documenttype; }
                set { documenttype = value; }
            }
            public string EndorsementCodeDescription
            {
                get { return endorsementcodedescription; }
                set { endorsementcodedescription = value; }
            }
            public string EndorsementsCode
            {
                get { return endorsementscode; }
                set { endorsementscode = value; }
            }
            public string ExceptionMessage
            {
                get { return exceptionmessage; }
                set { exceptionmessage = value; }
            }
            public string ExpirationDate
            {
                get { return expirationdate; }
                set { expirationdate = value; }
            }
            public string EyeColor
            {
                get { return eyecolor; }
                set { eyecolor = value; }
            }
            public string FirstName
            {
                get { return firstname; }
                set { firstname = value; }
            }
            public string FullName
            {
                get { return fullname; }
                set { fullname = value; }
            }
            public string Gender
            {
                get { return gender; }
                set { gender = value; }
            }
            public string HairColor
            {
                get { return haircolor; }
                set { haircolor = value; }
            }
            public string HAZMATExpDate
            {
                get { return hazmatexpdate; }
                set { hazmatexpdate = value; }
            }
            public string Height
            {
                get { return height; }
                set { height = value; }
            }
            public string IIN
            {
                get { return iin; }
                set { iin = value; }
            }
            public string IssueDate
            {
                get { return issuedate; }
                set { issuedate = value; }
            }
            public string IssuedBy
            {
                get { return issuedby; }
                set { issuedby = value; }
            }
            public string JurisdictionCode
            {
                get { return jurisdictioncode; }
                set { jurisdictioncode = value; }
            }
            public string LastName
            {
                get { return lastname; }
                set { lastname = value; }
            }
            public string LicenseNumber
            {
                get { return licensenumber; }
                set { licensenumber = value; }
            }
            public string LimitedDurationDocument
            {
                get { return limiteddurationdocument; }
                set { limiteddurationdocument = value; }
            }
            public string MiddleName
            {
                get { return middlename; }
                set { middlename = value; }
            }
            public string NamePrefix
            {
                get { return nameprefix; }
                set { nameprefix = value; }
            }
            public string NameSuffix
            {
                get { return namesuffix; }
                set { namesuffix = value; }
            }
            public string OrganDonor
            {
                get { return organdonor; }
                set { organdonor = value; }
            }
            public string PostalCode
            {
                get { return postalcode; }
                set { postalcode = value; }
            }
            public string Race
            {
                get { return race; }
                set { race = value; }
            }
            public string RestrictionCode
            {
                get { return restrictioncode; }
                set { restrictioncode = value; }
            }
            public string RestrictionCodeDescription
            {
                get { return restrictioncodedescription; }
                set { restrictioncodedescription = value; }
            }
            public string Specification
            {
                get { return specification; }
                set { specification = value; }
            }
            public string VehicleClassCode
            {
                get { return vehicleclasscode; }
                set { vehicleclasscode = value; }
            }
            public string VehicleClassCodeDescription
            {
                get { return vehicleclasscodedescription; }
                set { vehicleclasscodedescription = value; }
            }
            public string Veteran
            {
                get { return veteran; }
                set { veteran = value; }
            }
            public string WeightKG
            {
                get { return weightkg; }
                set { weightkg = value; }
            }
            public string WeightLBS
            {
                get { return weightlbs; }
                set { weightlbs = value; }
            }
            #endregion

            #region ********************************** Public Methods *****************************************
            public void Initialize()
            {
                address1 = string.Empty;
                address2 = string.Empty;
                birthdate = string.Empty;
                cardrevisiondate = string.Empty;
                city = string.Empty;
                classificationcode = string.Empty;
                compliancetype = string.Empty;
                country = string.Empty;
                documenttype = string.Empty;
                endorsementcodedescription = string.Empty;
                endorsementscode = string.Empty;
                exceptionmessage = string.Empty;
                expirationdate = string.Empty;
                eyecolor = string.Empty;
                firstname = string.Empty;
                fullname = string.Empty;
                gender = string.Empty;
                haircolor = string.Empty;
                hazmatexpdate = string.Empty;
                height = string.Empty;
                iin = string.Empty;
                issuedate = string.Empty;
                issuedby = string.Empty;
                jurisdictioncode = string.Empty;
                lastname = string.Empty;
                licensenumber = string.Empty;
                limiteddurationdocument = string.Empty;
                middlename = string.Empty;
                nameprefix = string.Empty;
                namesuffix = string.Empty;
                organdonor = string.Empty;
                postalcode = string.Empty;
                race = string.Empty;
                restrictioncode = string.Empty;
                restrictioncodedescription = string.Empty;
                specification = string.Empty;
                vehicleclasscode = string.Empty;
                vehicleclasscodedescription = string.Empty;
                veteran = string.Empty;
                weightkg = string.Empty;
                weightlbs = string.Empty;
            }
            #endregion
        }
    }
}
