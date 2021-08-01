using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.IO;
using MajorProjectLoanSystem.Models;

namespace MajorProjectLoanSystem
{
    public partial class HomeLoanDetails : System.Web.UI.Page
    {
        string PerRate1, PerRate2, PerRate3;
        double emi, lastEmi, interestAmt;

        int count = 11;
        string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            string tps1 = Convert.ToString(Session["Home_Rate1"]);
            var tp1 = tps1.Split(' ');
            string lastItem1 = tp1[tp1.Length - 1];
            var tpx1 = lastItem1.Split('%');
            PerRate1 = tpx1[0];

            string tps2 = Convert.ToString(Session["Home_Rate2"]);
            var tp2 = tps2.Split(' ');
            string lastItem2 = tp2[tp2.Length - 1];
            var tpx2 = lastItem2.Split('%');
            PerRate2 = tpx2[0];

            string tps3 = Convert.ToString(Session["Home_Rate3"]);
            var tp3 = tps3.Split(' ');
            string lastItem3 = tp3[tp3.Length - 1];
            var tpx3 = lastItem3.Split('%');
            PerRate3 = tpx3[0];

            if (!Page.IsPostBack)
            {
                
            }

            if (Session["USER_ID"] != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                    //GET Request StatusHome by id
                    var rT = client.GetAsync("StatusHome/" + Convert.ToInt32(Session["USER_ID"]));
                    rT.Wait();

                    var r = rT.Result;
                    if (r.IsSuccessStatusCode)
                    {
                        var readTask = r.Content.ReadAsAsync<StatusHomeClass>();
                        readTask.Wait();

                        var edit = readTask.Result;

                        if(edit.Home_Status == "Pending")
                        {
                            //Alert for Editing Details
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "editAlert()", true);

                            //GET by ID methods calling
                            //Personal_Get_Id();
                            //Gstin_Get_Id();
                            //EmpEduHome_Get_Id();
                            //Financial_Get_Id();
                            //PropHome_Get_Id();
                            //HomeDetails_Get_Id();
                            //PropertyDetails_Get_Id();
                            //Reference_Get_Id();
                            //Declar_Get_Id();
                            //HomeAppDoc_Get_Id();
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

            message = ddl5LoanRequired.SelectedItem.Value;
            if(message == "Home Loan")
            {
                count = 11;

                //Property Column
                ddl6PropertyType2.Enabled = false;
                ddl6PropertyClassification2.Enabled = false;
                txt6BuildingAge2.Enabled = false;
                txt6MarketValue2.Enabled = false;
                txt6RegisteredValue2.Enabled = false;
                txt6Area2.Enabled = false;
                txt6BuildArea2.Enabled = false;
                txt6Address2.Enabled = false;
                txt6landmark2.Enabled = false;
                txt6Pin2.Enabled = false;
                txt6City2.Enabled = false;
                txt6State2.Enabled = false;
                txt6Country2.Enabled = false;
                ddl6ApplicationFor2.Enabled = false;
                txt6LumpsumPlan2.Enabled = false;
                ddl6AnnuityPeriod2.Enabled = false;
                RequiredFieldValidator24.Enabled = false;
                RequiredFieldValidator25.Enabled = false;
                RequiredFieldValidator26.Enabled = false;
                RequiredFieldValidator27.Enabled = false;
                RequiredFieldValidator30.Enabled = false;
                RequiredFieldValidator33.Enabled = false;
                RequiredFieldValidator35.Enabled = false;
                RequiredFieldValidator37.Enabled = false;
                RequiredFieldValidator39.Enabled = false;
                RequiredFieldValidator46.Enabled = false;
                RequiredFieldValidator48.Enabled = false;
                RequiredFieldValidator50.Enabled = false;

                //Home Column
                ddl6PropertyType1.Enabled = true;
                ddl6TransactionType1.Enabled = true;
                txt6BuilderName1.Enabled = true;
                txt6PropertName1.Enabled = true;
                txt6BuildingName1.Enabled = true;
                txt6Area1.Enabled = true;
                txt6PropertyCost1.Enabled = true;
                txt6Address1.Enabled = true;
                txt6landmark1.Enabled = true;
                txt6Pin1.Enabled = true;
                txt6City1.Enabled = true;
                txt6State1.Enabled = true;
                txt6Country1.Enabled = true;
                txt6Ownership1.Enabled = true;
                txt6SellerName1.Enabled = true;
                txt6SellerAddress1.Enabled = true;
                ddl6ConstructionStage.Enabled = true;
                txt6PurchaseCost.Enabled = true;
                txt6RegistratonCost.Enabled = true;
                txt6TotalCost.Enabled = true;
                txt6StampCost.Enabled = true;
                txt6OtherCost.Enabled = true;
                txt6OwnContribution.Enabled = true;
                RequiredFieldValidator22.Enabled = true;
                RequiredFieldValidator23.Enabled = true;
                RequiredFieldValidator29.Enabled = true;
                RequiredFieldValidator32.Enabled = true;
                RequiredFieldValidator34.Enabled = true;
                RequiredFieldValidator36.Enabled = true;
                RequiredFieldValidator38.Enabled = true;
                RequiredFieldValidator40.Enabled = true;
                RequiredFieldValidator47.Enabled = true;
                RequiredFieldValidator49.Enabled = true;
                RequiredFieldValidator57.Enabled = true;

                //Documents Table
                //PropertyTaxFileUpload.Enabled = false;
                //lbl8PropertyTax.Visible = false;
                //RequiredFieldValidator8.Enabled = false;
                //ElecticityBillFileUpload.Enabled = true;
                //lbl8ElectricityBill.Visible = true;
                //RequiredFieldValidator10.Enabled = true;
                //AdvancePaymentFileUpload.Enabled = true;
                //lbl8AdvancePayment.Visible = true;
                //RequiredFieldValidator20.Enabled = true;
            }
            else if(message == "Loan Against Property")
            {

                count = 22;

                //Home Column
                ddl6PropertyType1.Enabled = false;
                ddl6TransactionType1.Enabled = false;
                txt6BuilderName1.Enabled = false;
                txt6PropertName1.Enabled = false;
                txt6BuildingName1.Enabled = false;
                txt6Area1.Enabled = false;
                txt6PropertyCost1.Enabled = false;
                txt6Address1.Enabled = false;
                txt6landmark1.Enabled = false;
                txt6Pin1.Enabled = false;
                txt6City1.Enabled = false;
                txt6State1.Enabled = false;
                txt6Country1.Enabled = false;
                txt6Ownership1.Enabled = false;
                txt6SellerName1.Enabled = false;
                txt6SellerAddress1.Enabled = false;
                ddl6ConstructionStage.Enabled = false;
                txt6PurchaseCost.Enabled = false;
                txt6RegistratonCost.Enabled = false;
                txt6TotalCost.Enabled = false;
                txt6StampCost.Enabled = false;
                txt6OtherCost.Enabled = false;
                txt6OwnContribution.Enabled = false;
                RequiredFieldValidator22.Enabled = false;
                RequiredFieldValidator23.Enabled = false;
                RequiredFieldValidator29.Enabled = false;
                RequiredFieldValidator32.Enabled = false;
                RequiredFieldValidator34.Enabled = false;
                RequiredFieldValidator36.Enabled = false;
                RequiredFieldValidator38.Enabled = false;
                RequiredFieldValidator40.Enabled = false;
                RequiredFieldValidator47.Enabled = false;
                RequiredFieldValidator49.Enabled = false;
                RequiredFieldValidator57.Enabled = false;

                //Property Column
                ddl6PropertyType2.Enabled = true;
                ddl6PropertyClassification2.Enabled = true;
                txt6BuildingAge2.Enabled = true;
                txt6MarketValue2.Enabled = true;
                txt6RegisteredValue2.Enabled = true;
                txt6Area2.Enabled = true;
                txt6BuildArea2.Enabled = true;
                txt6Address2.Enabled = true;
                txt6landmark2.Enabled = true;
                txt6Pin2.Enabled = true;
                txt6City2.Enabled = true;
                txt6State2.Enabled = true;
                txt6Country2.Enabled = true;
                ddl6ApplicationFor2.Enabled = true;
                txt6LumpsumPlan2.Enabled = true;
                ddl6AnnuityPeriod2.Enabled = true;
                RequiredFieldValidator24.Enabled = true;
                RequiredFieldValidator25.Enabled = true;
                RequiredFieldValidator26.Enabled = true;
                RequiredFieldValidator27.Enabled = true;
                RequiredFieldValidator30.Enabled = true;
                RequiredFieldValidator33.Enabled = true;
                RequiredFieldValidator35.Enabled = true;
                RequiredFieldValidator37.Enabled = true;
                RequiredFieldValidator39.Enabled = true;
                RequiredFieldValidator46.Enabled = true;
                RequiredFieldValidator48.Enabled = true;
                RequiredFieldValidator50.Enabled = true;

                //Documents Table
                //PropertyTaxFileUpload.Enabled = true;
                //lbl8PropertyTax.Visible = true;
                //RequiredFieldValidator8.Enabled = true;
                //ElecticityBillFileUpload.Enabled = false;
                //lbl8ElectricityBill.Visible = false;
                //RequiredFieldValidator10.Enabled = false;
                //AdvancePaymentFileUpload.Enabled = false;
                //lbl8AdvancePayment.Visible = false;
                //RequiredFieldValidator20.Enabled = false;
            }
            
        }

        protected void submit6_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //GET Request StatusHome by id
                var rT = client.GetAsync("StatusHome/" + Convert.ToInt32(Session["USER_ID"]));
                rT.Wait();

                var r = rT.Result;
                if (r.IsSuccessStatusCode)
                {
                    //PUT methods calling
                    Personal_Put_Id();
                    Gstin_Put_Id();
                    EmpEduHome_Put_Id();
                    Financial_Put_Id();
                    PropHome_Put_Id();
                    HomeDetails_Put_Id();
                    PropertyDetails_Put_Id();
                    Reference_Put_Id();
                    Declar_Put_Id();
                    HomeAppDoc_Put_Id();

                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "successAlert()", true);
                }
                else
                {
                    //POST method calling
                    if(message == "Home Loan")
                    {
                        Personal_Post();
                        Gstin_Post();
                        EmpEduHome_Post();
                        Financial_Post();
                        PropHome_Post();
                        HomeDetails_Post();
                        Reference_Post();
                        Declar_Post();
                        HomeAppDoc_Post();

                        Emi_Calculation_Method();

                        lblApp_ID.Text = GenerateID();
                        LoanAppliedDetailsHome_Post();
                        StatusHome_Post();

                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "successAlert()", true);
                    }
                    else if(message == "Loan Against Property")
                    {
                        Personal_Post();
                        Gstin_Post();
                        EmpEduHome_Post();
                        Financial_Post();
                        PropHome_Post();
                        PropertyDetails_Post();
                        Reference_Post();
                        Declar_Post();
                        HomeAppDoc_Post();

                        Emi_Calculation_Method();

                        lblApp_ID.Text = GenerateID();
                        LoanAppliedDetailsHome_Post();
                        StatusHome_Post();

                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "successAlert()", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "errorAlert()", true);
                    }

                }
            }
        }

        //GET Methods
        public void Personal_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("Personal/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PersonalClass>();
                    readTask.Wait();

                    var personal = readTask.Result;

                    var app_name = personal.App_Name.Split('_');
                    var app_fath_spou_name = personal.App_Fath_Spou_Name.Split('_');
                    var app_mother_name = personal.App_Mother_Name.Split('_');
                    var app_religion = personal.App_Religion.Split('_');
                    var app_category = personal.App_Category.Split('_');
                    var app_education = personal.App_Education.Split('_');

                    txt1ApplicantFirst.Text = app_name[0];
                    txt1ApplicantMiddle.Text = app_name[1];
                    txt1ApplicantLast.Text = app_name[2];
                    txt1FatherFirst.Text = app_fath_spou_name[0];
                    txt1FatherMiddle.Text = app_fath_spou_name[1];
                    txt1FatherLast.Text = app_fath_spou_name[2];
                    txt1MotherFirst.Text = app_mother_name[0];
                    txt1MotherMiddle.Text = app_mother_name[1];
                    txt1MotherLast.Text = app_mother_name[2];
                    ddl1Status.SelectedValue = personal.App_Status;
                    txt1PAN.Text = personal.App_Pan;
                    ddl1Document.SelectedValue = personal.App_Doc_Type;
                    txt1Document.Text = personal.App_Doc_No;
                    txt1Expiry.Text = Convert.ToString(personal.App_Doc_Exp);
                    txt1CKYC.Text = personal.App_Ckyc_No;
                    txt1DOB.Text = Convert.ToString(personal.App_Dob);
                    ddl1Gender.SelectedValue = personal.App_Gender;
                    txt1Nationality.Text = personal.App_Nationality;
                    ddl1Community.SelectedValue = app_religion[0];
                    txt1Community.Text = app_religion[1];
                    ddl1Category.SelectedValue = app_category[0];
                    txtCategory.Text = app_category[1];
                    ddl1Disability.SelectedValue = personal.App_Disability;
                    ddl1Education.SelectedValue = app_education[0];
                    txt1Education.Text = app_education[1];
                    ddl1Marital.SelectedValue = personal.App_Marital_Status;
                    txt1Dependents.Text = Convert.ToString(personal.App_Dependants_No);
                    txt1PersonalEmail.Text = personal.App_Email;
                    txt1OfficialEmail.Text = personal.App_Off_Email;
                    txt1Telephone.Text = Convert.ToString(personal.App_Telephone);
                    txt1Mobile.Text = Convert.ToString(personal.App_Mobile);
                    txt1PresentAddress.Text = personal.App_Pre_Addr;
                    txt1PresentLandmark.Text = personal.App_Pre_Landmark;
                    txt1PresentPostal.Text = Convert.ToString(personal.App_Pre_Pin);
                    txt1PresentCity.Text = personal.App_Pre_City;
                    txt1PresentState.Text = personal.App_Pre_State;
                    txt1PermanentAddress.Text = personal.App_Per_Addr;
                    txt1PermanentLandmark.Text = personal.App_Per_Landmark;
                    txt1PermanentPostal.Text = Convert.ToString(personal.App_Per_Pin);
                    txt1PermanentCity.Text = personal.App_Per_City;
                    txt1PermanentState.Text = personal.App_Per_State;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void Gstin_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("Gstin/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<GstinClass>();
                    readTask.Wait();

                    var gstin = readTask.Result;

                    ddl21UnderGst.SelectedValue = gstin.Gst_Reg;
                    ddl22GstExemption.SelectedValue = gstin.Gst_Exem;
                    txt2ExemptionReason.Text = gstin.Gst_Exem_Reason;
                    txt2ExemptionValid.Text = Convert.ToString(gstin.Gst_Exem_date);
                    txt2GstinDate.Text = Convert.ToString(gstin.Gst_Reg_Date);
                    ddl2GstType.SelectedValue = gstin.Gst_Reg_Type;
                    txt2GstZone.Text = gstin.Gst_Eco_Zone;
                    txt2GstinDefault.Text = gstin.Gst_default;
                    txt2GstinAddress.Text = gstin.Gstin_Addr;
                    txt2Pin.Text = Convert.ToString(gstin.Gst_Pin);
                    txt2City.Text = gstin.Gst_City;
                    txt2State.Text = gstin.Gst_State;
                    txt2Country.Text = gstin.Gst_Country;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void EmpEduHome_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("EmpEduHome/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EmpEduHomeClass>();
                    readTask.Wait();

                    var empeduhome = readTask.Result;

                    var org_employment_nat = empeduhome.Org_Employment_Nat.Split('_');
                    var org_nat = empeduhome.Org_Nat.Split('_');

                    ddl3ResidenceOwnership.SelectedValue = empeduhome.Org_Res_Own;
                    ddl3EmploymentNature.SelectedValue = empeduhome.Org_Employment_Nat;
                    txt3Designation.Text = empeduhome.Org_Designation;
                    ddl3EmployerNature.SelectedValue = org_employment_nat[0];
                    txt3EmployerNatureOther.Text = org_employment_nat[1];
                    ddl3OrganisationNature.SelectedValue = org_nat[0];
                    txt6OrganisationTypeOther.Text = org_nat[1];
                    txt3CurrentEmploymentYear.Text = empeduhome.Org_Current_Year;
                    txt3TotalEmploymentYear.Text = empeduhome.Org_Total_Year;
                    txt3OrganisationName.Text = empeduhome.Org_Name;
                    txt3Address.Text = empeduhome.Org_Address;
                    txt3City.Text = empeduhome.Org_City;
                    txt3State.Text = empeduhome.Org_State;
                    txt3PinCode.Text = Convert.ToString(empeduhome.Org_Pin);
                    txt3Country.Text = empeduhome.Org_Country;
                    txt3Phone.Text = Convert.ToString(empeduhome.Org_Phone);
                    txt3Uan.Text = empeduhome.Org_UAN;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void PropHome_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("PropHome/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PropHomeClass>();
                    readTask.Wait();

                    var prophome = readTask.Result;

                    var pr_loan_purpose = prophome.Pr_Loan_Purpose.Split('_');
                    var pr_loan_prod_categ = prophome.Pr_Loan_Prod_Categ.Split('_');

                    ddl5LoanRequired.SelectedValue = prophome.Pr_Loan_For;
                    txt5LoanAmount.Text = Convert.ToString(prophome.Pr_Amount);
                    txt5Terms.Text = Convert.ToString(prophome.Pr_Terms);
                    ddl5LoanPurpose.SelectedValue = pr_loan_purpose[0];
                    txt5LoanPurpose.Text = pr_loan_purpose[1];
                    ddl5LoanProductType.SelectedValue = pr_loan_prod_categ[0];
                    txt5LoanProductTypeOther.Text = pr_loan_prod_categ[1];
                    ddl5RepaymentMode.SelectedValue = prophome.Pr_Repay_Mode;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void HomeDetails_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("HomeDetails/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<HomeDetailsClass>();
                    readTask.Wait();

                    var homedetails = readTask.Result;

                    ddl6PropertyType1.SelectedValue = homedetails.Prop_Type;
                    ddl6TransactionType1.SelectedValue = homedetails.Prop_Trans_Type;
                    txt6BuilderName1.Text = homedetails.Prop_Builder_Name;
                    txt6PropertName1.Text = homedetails.Prop_Project_Name;
                    txt6BuildingName1.Text = homedetails.Prop_Building_Name;
                    txt6Area1.Text = Convert.ToString(homedetails.Prop_Land_Area);
                    txt6PropertyCost1.Text = Convert.ToString(homedetails.Prop_Cost);
                    txt6Address1.Text = homedetails.Prop_Addr;
                    txt6landmark1.Text = homedetails.Prop_Landmark;
                    txt6Pin1.Text = Convert.ToString(homedetails.Prop_Pin);
                    txt6City1.Text = homedetails.Prop_City;
                    txt6State1.Text = homedetails.Prop_State;
                    txt6Country1.Text = homedetails.Prop_Country;
                    txt6Ownership1.Text = homedetails.Prop_Ownership;
                    txt6SellerName1.Text = homedetails.Prop_Seller_Name;
                    txt6SellerAddress1.Text = homedetails.Prop_Seller_Addr;
                    ddl6ConstructionStage.SelectedValue = homedetails.Prop_Const_Stage;
                    txt6PurchaseCost.Text = Convert.ToString(homedetails.Prop_Pur_Con_Cost);
                    txt6RegistratonCost.Text = Convert.ToString(homedetails.Prop_Reg_Cost);
                    txt6TotalCost.Text = Convert.ToString(homedetails.Prop_Total_Cost);
                    txt6StampCost.Text = Convert.ToString(homedetails.Prop_Stamp_Cost);
                    txt6OtherCost.Text = Convert.ToString(homedetails.Prop_Other_Cost);
                    txt6OwnContribution.Text = Convert.ToString(homedetails.Prop_Own_Contrib);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void PropertyDetails_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("PropertyDetails/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PropertyDetailsClass>();
                    readTask.Wait();

                    var propertydetails = readTask.Result;

                    ddl6PropertyType2.SelectedValue = propertydetails.Ag_Prop_Type;
                    ddl6PropertyClassification2.SelectedValue = propertydetails.Ag_Prop_Classif;
                    txt6BuildingAge2.Text = Convert.ToString(propertydetails.Ag_Building_Age);
                    txt6MarketValue2.Text = Convert.ToString(propertydetails.Ag_Market_Value);
                    txt6RegisteredValue2.Text = Convert.ToString(propertydetails.Ag_Regis_Value);
                    txt6Area2.Text = Convert.ToString(propertydetails.Ag_Prop_Land_Area);
                    txt6BuildArea2.Text = Convert.ToString(propertydetails.Ag_Buildup_Area);
                    txt6Address2.Text = propertydetails.Ag_Prop_Addr;
                    txt6landmark2.Text = propertydetails.Ag_Landmark;
                    txt6Pin2.Text = Convert.ToString(propertydetails.Ag_Pin);
                    txt6City2.Text = propertydetails.Ag_City;
                    txt6State2.Text = propertydetails.Ag_State;
                    txt6Country2.Text = propertydetails.Ag_Country;
                    ddl6ApplicationFor2.SelectedValue = propertydetails.Ag_Rev_Mortage;
                    txt6LumpsumPlan2.Text = Convert.ToString(propertydetails.Ag_Lumpsum_Amount);
                    ddl6AnnuityPeriod2.SelectedValue = propertydetails.Ag_Annuity_Periodicity;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void Financial_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("Financial/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<FinancialClass>();
                    readTask.Wait();

                    var financial = readTask.Result;

                    ddl4FinancialStatus.SelectedValue = financial.Fin_Status;
                    txt4GrossIncome.Text = Convert.ToString(financial.Fin_Inc_Gross);
                    txt4NetIncome.Text = Convert.ToString(financial.Fin_Inc_Net);
                    txt4OtherIncome.Text = Convert.ToString(financial.Fin_Inc_Othr);
                    txt4TotalIncome.Text = Convert.ToString(financial.Fin_Inc_Total);
                    txt4Bank1.Text = financial.Fin_Bank1_Name;
                    txt4Branch1.Text = financial.Fin_Bank1_Branch;
                    txt4AccountType1.Text = financial.Fin_Bank1_Ac_Type;
                    txt4AccountNo1.Text = financial.Fin_Bank1_Ac_No;
                    txt4Bank2.Text = financial.Fin_Bank2_Name;
                    txt4Branch2.Text = financial.Fin_Bank2_Branch;
                    txt4AccountType2.Text = financial.Fin_Bank2_Ac_Type;
                    txt4AccountNo2.Text = financial.Fin_Bank2_Ac_No;
                    txt4Deposits.Text = Convert.ToString(financial.Fin_Deposits_Inv);
                    txt4Insurance.Text = Convert.ToString(financial.Fin_Insurance_Inv);
                    txt4Shares.Text = Convert.ToString(financial.Fin_Shares_Inv);
                    txt4MutualFunds.Text = Convert.ToString(financial.Fin_Mutual_Funds_Inv);
                    txt4Others.Text = Convert.ToString(financial.Fin_Others_Inv);
                    txt4TotalInvestment.Text = Convert.ToString(financial.Fin_Total_Inv);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void Reference_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("Reference/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ReferenceClass>();
                    readTask.Wait();

                    var reference = readTask.Result;

                    txt7Name1.Text = reference.Ref_Name1;
                    txt7Relation1.Text = reference.Ref_Relat1;
                    txt7Address1.Text = reference.Ref_Addr1;
                    txt7Pin1.Text = Convert.ToString(reference.Ref_Pin1);
                    txt7City1.Text = reference.Ref_City1;
                    txt7State1.Text = reference.Ref_State1;
                    txt7Country1.Text = reference.Ref_Country1;
                    txt7Mobile1.Text = Convert.ToString(reference.Ref_Mob_Tel1);
                    txt7Email1.Text = reference.Ref_Email1;
                    txt7Name2.Text = reference.Ref_Name2;
                    txt7Relation2.Text = reference.Ref_Relat2;
                    txt7Address2.Text = reference.Ref_Addr2;
                    txt7Pin2.Text = Convert.ToString(reference.Ref_Pin2);
                    txt7City2.Text = reference.Ref_City2;
                    txt7State2.Text = reference.Ref_State2;
                    txt7Country2.Text = reference.Ref_Country2;
                    txt7Mobile2.Text = Convert.ToString(reference.Ref_Mob_Tel2);
                    txt7Email2.Text = reference.Ref_Email2;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void Declar_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("Declar/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<DeclarClass>();
                    readTask.Wait();

                    var declare = readTask.Result;

                    string str1Base64 = Convert.ToBase64String(declare.Dec_App_Photo);
                    string str2Base64 = Convert.ToBase64String(declare.Dec_App_Sign);

                    txt8Place.Text = declare.Dec_Place;
                    txt8DateOfDeclaration.Text = Convert.ToString(declare.Dec_Date);
                    output_image.ImageUrl = "data:Image/jpeg;base64," + str1Base64;
                    output_sign.ImageUrl = "data:Image/jpeg;base64," + str2Base64;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void HomeAppDoc_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("HomeAppDoc/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<HomeAppDocClass>();
                    readTask.Wait();

                    var homeappdoc = readTask.Result;

                    if (homeappdoc.Doc1 != null)
                    {
                        lbl8Identity.Text = "Submitted";
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        //POST Methods
        public void Personal_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in Personal table
                PersonalClass personal = new PersonalClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    App_Name = txt1ApplicantFirst.Text + "_" + txt1ApplicantMiddle.Text + "_" + txt1ApplicantLast.Text,
                    App_Fath_Spou_Name = txt1FatherFirst.Text + "_" + txt1FatherMiddle.Text + "_" + txt1FatherLast.Text,
                    App_Mother_Name = txt1MotherFirst.Text + "_" + txt1MotherMiddle.Text + "_" + txt1MotherLast.Text,
                    App_Status = ddl1Status.SelectedValue,
                    App_Pan = txt1PAN.Text,
                    App_Doc_Type = ddl1Document.SelectedValue,
                    App_Doc_No = txt1Document.Text,
                    App_Doc_Exp = Convert.ToDateTime(txt1Expiry.Text),
                    App_Ckyc_No = "O-" + txt1CKYC.Text,
                    App_Dob = Convert.ToDateTime(txt1DOB.Text),
                    App_Gender = ddl1Gender.SelectedValue,
                    App_Nationality = txt1Nationality.Text,
                    App_Religion = ddl1Community.SelectedValue + "_" + txt1Community.Text,
                    App_Category = ddl1Category.SelectedValue + "_" + txtCategory.Text,
                    App_Disability = ddl1Disability.SelectedValue,
                    App_Education = ddl1Education.SelectedValue + "_" + txt1Education.Text,
                    App_Marital_Status = ddl1Marital.SelectedValue,
                    App_Dependants_No = Convert.ToInt32(txt1Dependents.Text),
                    App_Email = txt1PersonalEmail.Text,
                    App_Off_Email = "O-" + txt1OfficialEmail.Text,
                    App_Telephone = 0 + Convert.ToInt64(txt1Telephone.Text),
                    App_Mobile = Convert.ToInt64(txt1Mobile.Text),
                    App_Pre_Addr = txt1PresentAddress.Text,
                    App_Pre_Landmark = txt1PresentLandmark.Text,
                    App_Pre_Pin = Convert.ToInt32(txt1PresentPostal.Text),
                    App_Pre_City = txt1PresentCity.Text,
                    App_Pre_State = txt1PresentState.Text,
                    App_Per_Addr = txt1PermanentAddress.Text,
                    App_Per_Landmark = txt1PermanentLandmark.Text,
                    App_Per_Pin = Convert.ToInt32(txt1PermanentPostal.Text),
                    App_Per_City = txt1PermanentCity.Text,
                    App_Per_State = txt1PermanentState.Text
                };

                var postTask = client.PostAsJsonAsync<PersonalClass>("Personal", personal);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void Gstin_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //Optional date data
                DateTime stxt2ExemptionValid;
                if (txt2ExemptionValid.Text == null)
                {
                    stxt2ExemptionValid = DateTime.Now;
                }
                else
                {
                    stxt2ExemptionValid = Convert.ToDateTime(txt2ExemptionValid.Text);
                }

                DateTime stxt2GstinDate;
                if (txt2GstinDate.Text == null)
                {
                    stxt2GstinDate = DateTime.Now;
                }
                else
                {
                    stxt2GstinDate = Convert.ToDateTime(txt2GstinDate.Text);
                }

                //HTTP POST in Gstin table
                var gstin = new GstinClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Gst_Reg = ddl21UnderGst.SelectedValue,
                    Gst_Exem = ddl22GstExemption.SelectedValue,
                    Gst_Exem_Reason = "O-" + txt2ExemptionReason.Text,
                    Gst_Exem_date = Convert.ToDateTime(txt2ExemptionValid.Text),
                    Gst_Reg_Date = Convert.ToDateTime(txt2GstinDate.Text),
                    Gst_Reg_Type = "O-" + ddl2GstType.SelectedValue,
                    Gst_Eco_Zone = "O-" + txt2GstZone.Text,
                    Gst_default = "O-" + txt2GstinDefault.Text,
                    Gstin_Addr = "O-" + txt2GstinAddress.Text,
                    Gst_Pin = 0 + Convert.ToInt32(txt2Pin.Text),
                    Gst_City = "O-" + txt2City.Text,
                    Gst_State = "O-" + txt2State.Text,
                    Gst_Country = "O-" + txt2Country.Text
                };

                var postTask = client.PostAsJsonAsync<GstinClass>("Gstin", gstin);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void EmpEduHome_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in EmpEduHome table
                var empeduhome = new EmpEduHomeClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Org_Res_Own = ddl3ResidenceOwnership.SelectedValue,
                    Org_Employment_Nat = "O-" + ddl3EmploymentNature.SelectedValue,
                    Org_Designation = "O-" + txt3Designation.Text,
                    Org_Nat = "O-" + ddl3EmployerNature.SelectedValue + "_" + txt3EmployerNatureOther.Text,
                    Org_Emp_Busi_Nat = "O-" + ddl3OrganisationNature.SelectedValue + "_" + txt6OrganisationTypeOther.Text,
                    Org_Current_Year = 0 + txt3CurrentEmploymentYear.Text,
                    Org_Total_Year = 0 + txt3TotalEmploymentYear.Text,
                    Org_Name = "O-" + txt3OrganisationName.Text,
                    Org_Address = "O-" + txt3Address.Text,
                    Org_Pin = 0 + Convert.ToInt32(txt3PinCode.Text),
                    Org_City = "O-" + txt3City.Text,
                    Org_State = "O-" + txt3State.Text,
                    Org_Country = "O-" + txt3Country.Text,
                    Org_Phone = 0 + Convert.ToInt64(txt3Phone.Text),
                    Org_UAN = "O-" + txt3Uan.Text
                };

                var postTask = client.PostAsJsonAsync<EmpEduHomeClass>("EmpEduHome", empeduhome);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void PropHome_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in PropHome table
                var prophome = new PropHomeClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Pr_Loan_For = ddl5LoanRequired.SelectedValue,
                    Pr_Amount = Convert.ToDecimal(txt5LoanAmount.Text),
                    Pr_Terms = Convert.ToInt32(txt5Terms.Text),
                    Pr_Loan_Purpose = ddl5LoanPurpose.SelectedValue + "_" + txt5LoanPurpose.Text,
                    Pr_Loan_Prod_Categ = ddl5LoanProductType.SelectedValue + "_" + txt5LoanProductTypeOther.Text,
                    Pr_Repay_Mode = ddl5RepaymentMode.SelectedValue
                };

                var postTask = client.PostAsJsonAsync<PropHomeClass>("PropHome", prophome);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void HomeDetails_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in HomeDetails table
                HomeDetailsClass homedetails = new HomeDetailsClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Prop_Type = ddl6PropertyType1.SelectedValue,
                    Prop_Trans_Type = ddl6TransactionType1.SelectedValue,
                    Prop_Builder_Name = "O-" + txt6BuilderName1.Text,
                    Prop_Project_Name = "O-" + txt6PropertName1.Text,
                    Prop_Building_Name = "O-" + txt6BuildingName1.Text,
                    Prop_Land_Area = Convert.ToDecimal(txt6Area1.Text),
                    Prop_Cost = Convert.ToDecimal(txt6PropertyCost1.Text),
                    Prop_Addr = txt6Address1.Text,
                    Prop_Landmark = txt6landmark1.Text,
                    Prop_Pin = Convert.ToInt32(txt6Pin1.Text),
                    Prop_City = txt6City1.Text,
                    Prop_State = txt6State1.Text,
                    Prop_Country = txt6Country1.Text,
                    Prop_Ownership = txt6Ownership1.Text,
                    Prop_Seller_Name = "O-" + txt6SellerName1.Text,
                    Prop_Seller_Addr = "O-" + txt6SellerAddress1.Text,
                    Prop_Const_Stage = ddl6ConstructionStage.SelectedValue,
                    Prop_Pur_Con_Cost = Convert.ToDecimal(txt6PurchaseCost.Text),
                    Prop_Reg_Cost = Convert.ToDecimal(txt6RegistratonCost.Text),
                    Prop_Total_Cost = Convert.ToDecimal(txt6TotalCost.Text),
                    Prop_Stamp_Cost = 0 + Convert.ToDecimal(txt6StampCost.Text),
                    Prop_Other_Cost = 0 + Convert.ToDecimal(txt6OtherCost.Text),
                    Prop_Own_Contrib = 0 + Convert.ToDecimal(txt6OwnContribution.Text)
                };

                var postTask = client.PostAsJsonAsync<HomeDetailsClass>("HomeDetails", homedetails);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void PropertyDetails_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in PropertyDetails table
                var propertydetails = new PropertyDetailsClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Ag_Prop_Type = ddl6PropertyType2.SelectedValue,
                    Ag_Prop_Classif = ddl6PropertyClassification2.SelectedValue,
                    Ag_Building_Age = Convert.ToInt32(txt6BuildingAge2.Text),
                    Ag_Market_Value = Convert.ToDecimal(txt6MarketValue2.Text),
                    Ag_Regis_Value = 0 + Convert.ToDecimal(txt6RegisteredValue2.Text),
                    Ag_Prop_Land_Area = Convert.ToDecimal(txt6Area2.Text),
                    Ag_Buildup_Area = Convert.ToDecimal(txt6BuildArea2.Text),
                    Ag_Prop_Addr = txt6Address2.Text,
                    Ag_Landmark = txt6landmark2.Text,
                    Ag_Pin = Convert.ToInt32(txt6Pin2.Text),
                    Ag_City = txt6City2.Text,
                    Ag_State = txt6State2.Text,
                    Ag_Country = txt6Country2.Text,
                    Ag_Rev_Mortage = "O-" + ddl6ApplicationFor2.SelectedValue,
                    Ag_Lumpsum_Amount = 0 + Convert.ToDecimal(txt6LumpsumPlan2.Text),
                    Ag_Annuity_Periodicity = "O-" + ddl6AnnuityPeriod2.SelectedValue
                };

                var postTask = client.PostAsJsonAsync<PropertyDetailsClass>("PropertyDetails", propertydetails);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void Financial_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in Financial table
                var financial = new FinancialClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Fin_Status = ddl4FinancialStatus.SelectedValue,
                    Fin_Inc_Gross = Convert.ToDecimal(txt4GrossIncome.Text),
                    Fin_Inc_Net = Convert.ToDecimal(txt4NetIncome.Text),
                    Fin_Inc_Othr = Convert.ToDecimal(txt4OtherIncome.Text),
                    Fin_Inc_Total = Convert.ToDecimal(txt4TotalIncome.Text),
                    Fin_Bank1_Name = "O-" + txt4Bank1.Text,
                    Fin_Bank1_Branch = "O-" + txt4Branch1.Text,
                    Fin_Bank1_Ac_Type = "O-" + txt4AccountType1.Text,
                    Fin_Bank1_Ac_No = "O-" + txt4AccountNo1.Text,
                    Fin_Bank2_Name = "O-" + txt4Bank2.Text,
                    Fin_Bank2_Branch = "O-" + txt4Branch2.Text,
                    Fin_Bank2_Ac_Type = "O-" + txt4AccountType2.Text,
                    Fin_Bank2_Ac_No = "O-" + txt4AccountNo2.Text,
                    Fin_Deposits_Inv = 0 + Convert.ToDecimal(txt4Deposits.Text),
                    Fin_Shares_Inv = 0 + Convert.ToDecimal(txt4Shares.Text),
                    Fin_Insurance_Inv = 0 + Convert.ToDecimal(txt4Insurance.Text),
                    Fin_Mutual_Funds_Inv = 0 + Convert.ToDecimal(txt4MutualFunds.Text),
                    Fin_Others_Inv = 0 + Convert.ToDecimal(txt4Others.Text),
                    Fin_Total_Inv = 0 + Convert.ToDecimal(txt4TotalInvestment.Text)
                };

                var postTask = client.PostAsJsonAsync<FinancialClass>("Financial", financial);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void Reference_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in Reference table
                ReferenceClass reference = new ReferenceClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Ref_Name1 = txt7Name1.Text,
                    Ref_Relat1 = txt7Relation1.Text,
                    Ref_Addr1 = txt7Address1.Text,
                    Ref_Pin1 = Convert.ToInt32(txt7Pin1.Text),
                    Ref_City1 = txt7City1.Text,
                    Ref_State1 = txt7State1.Text,
                    Ref_Country1 = txt7Country1.Text,
                    Ref_Mob_Tel1 = Convert.ToInt64(txt7Mobile1.Text),
                    Ref_Email1 = txt7Email1.Text,
                    Ref_Name2 = "O-" + txt7Name2.Text,
                    Ref_Relat2 = "O-" + txt7Relation2.Text,
                    Ref_Addr2 = "O-" + txt7Address2.Text,
                    Ref_Pin2 = 0 + Convert.ToInt32(txt7Pin2.Text),
                    Ref_City2 = "O-" + txt7City2.Text,
                    Ref_State2 = "O-" + txt7State2.Text,
                    Ref_Country2 = "O-" + txt7Country2.Text,
                    Ref_Mob_Tel2 = 0 + Convert.ToInt64(txt7Mobile2.Text),
                    Ref_Email2 = "O-" + txt7Email2.Text
                };

                var postTask = client.PostAsJsonAsync<ReferenceClass>("Reference", reference);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void Declar_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                byte[] bytes1 = null;
                if (imageFileUpload.PostedFile != null)
                {
                    HttpPostedFile postedFile1 = imageFileUpload.PostedFile;
                    string doc_File1 = Path.GetFileName(imageFileUpload.PostedFile.FileName);
                    Stream stream1 = postedFile1.InputStream;
                    BinaryReader binaryReader1 = new BinaryReader(stream1);
                    bytes1 = binaryReader1.ReadBytes((int)stream1.Length);

                }

                byte[] bytes2 = null;
                if (signFileUpload.PostedFile != null)
                {
                    HttpPostedFile postedFile2 = signFileUpload.PostedFile;
                    string doc_File2 = Path.GetFileName(signFileUpload.PostedFile.FileName);
                    Stream stream2 = postedFile2.InputStream;
                    BinaryReader binaryReader2 = new BinaryReader(stream2);
                    bytes2 = binaryReader2.ReadBytes((int)stream2.Length);

                }

                //HTTP POST in Declar table
                var declar = new DeclarClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Dec_Place = txt8Place.Text,
                    Dec_Date = Convert.ToDateTime(txt8DateOfDeclaration.Text),
                    Dec_App_Photo = bytes1,
                    Dec_App_Sign = bytes2
                };

                var postTask = client.PostAsJsonAsync<DeclarClass>("Declar", declar);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void HomeAppDoc_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                byte[] bytes1 = null;
                if (identityFileUpload.PostedFile != null)
                {
                    HttpPostedFile postedFile1 = identityFileUpload.PostedFile;
                    string doc_File1 = Path.GetFileName(identityFileUpload.PostedFile.FileName);
                    Stream stream1 = postedFile1.InputStream;
                    BinaryReader binaryReader1 = new BinaryReader(stream1);
                    bytes1 = binaryReader1.ReadBytes((int)stream1.Length);

                }

                byte[] bytes2 = null;
                if (residenceFileUpload.PostedFile != null)
                {
                    HttpPostedFile postedFile2 = residenceFileUpload.PostedFile;
                    string doc_File2 = Path.GetFileName(residenceFileUpload.PostedFile.FileName);
                    Stream stream2 = postedFile2.InputStream;
                    BinaryReader binaryReader2 = new BinaryReader(stream2);
                    bytes2 = binaryReader2.ReadBytes((int)stream2.Length);

                }

                byte[] bytes3 = null;
                if (financialFileUpload.PostedFile != null)
                {
                    HttpPostedFile postedFile3 = financialFileUpload.PostedFile;
                    string doc_File3 = Path.GetFileName(financialFileUpload.PostedFile.FileName);
                    Stream stream3 = postedFile3.InputStream;
                    BinaryReader binaryReader3 = new BinaryReader(stream3);
                    bytes3 = binaryReader3.ReadBytes((int)stream3.Length);

                }

                byte[] bytes4 = null;
                if (ageFileUpload.PostedFile != null)
                {
                    HttpPostedFile postedFile4 = ageFileUpload.PostedFile;
                    string doc_File4 = Path.GetFileName(ageFileUpload.PostedFile.FileName);
                    Stream stream4 = postedFile4.InputStream;
                    BinaryReader binaryReader4 = new BinaryReader(stream4);
                    bytes4 = binaryReader4.ReadBytes((int)stream4.Length);

                }

                byte[] bytes5 = null;
                if (saleDeedFileUpload.PostedFile != null)
                {
                    HttpPostedFile postedFile5 = saleDeedFileUpload.PostedFile;
                    string doc_File5 = Path.GetFileName(saleDeedFileUpload.PostedFile.FileName);
                    Stream stream5 = postedFile5.InputStream;
                    BinaryReader binaryReader5 = new BinaryReader(stream5);
                    bytes5 = binaryReader5.ReadBytes((int)stream5.Length);

                }

                byte[] bytes6 = null;
                if (PropertyTaxFileUpload.PostedFile != null)
                {
                    HttpPostedFile postedFile6= PropertyTaxFileUpload.PostedFile;
                    string doc_File6 = Path.GetFileName(PropertyTaxFileUpload.PostedFile.FileName);
                    Stream stream6 = postedFile6.InputStream;
                    BinaryReader binaryReader6 = new BinaryReader(stream6);
                    bytes6 = binaryReader6.ReadBytes((int)stream6.Length);

                }

                byte[] bytes7 = null;
                if (AdvancePaymentFileUpload.PostedFile != null)
                {
                    HttpPostedFile postedFile7 = AdvancePaymentFileUpload.PostedFile;
                    string doc_File7 = Path.GetFileName(AdvancePaymentFileUpload.PostedFile.FileName);
                    Stream stream7 = postedFile7.InputStream;
                    BinaryReader binaryReader7 = new BinaryReader(stream7);
                    bytes7 = binaryReader7.ReadBytes((int)stream7.Length);

                }

                //HTTP POST in HomeAppDoc table
                var homeappdoc = new HomeAppDocClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Doc1_Name = ddl8Identity.SelectedValue,
                    Doc1 = bytes1,
                    Doc1_Status = "Pending",
                    Doc2_Name = ddl8Residence.SelectedValue,
                    Doc2 = bytes2,
                    Doc2_Status = "Pending",
                    Doc3_Name = ddl8Financial.SelectedValue,
                    Doc3 = bytes3,
                    Doc3_Status = "Pending",
                    Doc4_Name = ddl8Age.SelectedValue,
                    Doc4 = bytes4,
                    Doc4_Status = "Pending",
                    Doc5_Name = "Registered Sale Deed",
                    Doc5 = bytes5,
                    Doc5_Status = "Pending",
                    Doc6_Name = "Electricity0R Property Tax",
                    Doc6 = bytes6,
                    Doc6_Status = "Pending",
                    Doc7_Name = "Advance Payment OR IT",
                    Doc7 = bytes7,
                    Doc7_Status = "Pending",
                };

                var postTask = client.PostAsJsonAsync<HomeAppDocClass>("HomeAppDoc", homeappdoc);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void LoanAppliedDetailsHome_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                double pp = Convert.ToDouble(txt5LoanAmount.Text);
                double rat;

                if (pp <= 3000000)
                {
                    rat = Convert.ToDouble(PerRate1);
                }
                else if (pp < 7000000)
                {
                    rat = Convert.ToDouble(PerRate2);
                }
                else
                {
                    rat = Convert.ToDouble(PerRate3);
                }

                //HTTP POST in LoanAppliedDetails table
                var ladp = new LoanAppliedDetailsHomeClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Home_ID = lblApp_ID.Text,
                    Home_Amount = Convert.ToDecimal(txt5LoanAmount.Text),
                    Home_Rate = Convert.ToDecimal(rat),
                    Home_Tenure = Convert.ToInt32(txt5Terms.Text),
                    Home_Emi = Convert.ToDecimal(emi),
                    Home_Last_Emi = Convert.ToDecimal(lastEmi),
                    Home_Interest = Convert.ToDecimal(interestAmt)
                };

                var postTask = client.PostAsJsonAsync<LoanAppliedDetailsHomeClass>("LoanAppliedDetailsHome", ladp);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void StatusHome_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in Status table
                var sp = new StatusHomeClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Home_Applied = "Yes",
                    Home_Status = "Pending",
                    Home_Correction = "NA"
                };

                var postTask = client.PostAsJsonAsync<StatusHomeClass>("StatusHome", sp);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        //PUT Methods
        public void Personal_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP PUT in Personal table
                var personal = new PersonalClass()
                {
                    App_Name = txt1ApplicantFirst.Text + txt1ApplicantMiddle.Text + txt1ApplicantLast.Text,
                    App_Fath_Spou_Name = txt1FatherFirst.Text + txt1FatherMiddle.Text + txt1FatherLast.Text,
                    App_Mother_Name = txt1MotherFirst.Text + txt1MotherMiddle.Text + txt1MotherLast.Text,
                    App_Status = ddl1Status.SelectedValue,
                    App_Pan = txt1PAN.Text,
                    App_Doc_Type = ddl1Document.SelectedValue,
                    App_Doc_No = txt1Document.Text,
                    App_Doc_Exp = Convert.ToDateTime(txt1Expiry),
                    App_Ckyc_No = txt1CKYC.Text,
                    App_Dob = Convert.ToDateTime(txt1DOB),
                    App_Gender = ddl1Gender.SelectedValue,
                    App_Nationality = txt1Nationality.Text,
                    App_Religion = ddl1Community.SelectedValue + txt1Community.Text,
                    App_Category = ddl1Category.SelectedValue + txtCategory.Text,
                    App_Disability = ddl1Disability.SelectedValue,
                    App_Education = ddl1Education.SelectedValue + txt1Education.Text,
                    App_Marital_Status = ddl1Marital.SelectedValue,
                    App_Dependants_No = Convert.ToInt32(txt1Dependents),
                    App_Email = txt1PersonalEmail.Text,
                    App_Off_Email = txt1OfficialEmail.Text,
                    App_Telephone = Convert.ToInt64(txt1Telephone),
                    App_Mobile = Convert.ToInt64(txt1Mobile),
                    App_Pre_Addr = txt1PresentAddress.Text,
                    App_Pre_Landmark = txt1PresentLandmark.Text,
                    App_Pre_Pin = Convert.ToInt32(txt1PresentPostal),
                    App_Pre_City = txt1PresentCity.Text,
                    App_Pre_State = txt1PresentState.Text,
                    App_Per_Addr = txt1PermanentAddress.Text,
                    App_Per_Landmark = txt1PermanentLandmark.Text,
                    App_Per_Pin = Convert.ToInt32(txt1PermanentPostal),
                    App_Per_City = txt1PermanentCity.Text,
                    App_Per_State = txt1PermanentState.Text
                };

                var putTask = client.PutAsJsonAsync<PersonalClass>("Personal/" + Convert.ToInt32(Session["USER_ID"]), personal);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void Gstin_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP PUT in Gstin table
                var gstin = new GstinClass()
                {
                    Gst_Reg = ddl21UnderGst.SelectedValue,
                    Gst_Exem = ddl22GstExemption.SelectedValue,
                    Gst_Exem_Reason = txt2ExemptionReason.Text,
                    Gst_Exem_date = Convert.ToDateTime(txt2ExemptionValid.Text),
                    Gst_Reg_Date = Convert.ToDateTime(txt2GstinDate),
                    Gst_Reg_Type = ddl2GstType.SelectedValue,
                    Gst_Eco_Zone = txt2GstZone.Text,
                    Gst_default = txt2GstinDefault.Text,
                    Gstin_Addr = txt2GstinAddress.Text,
                    Gst_Pin = Convert.ToInt32(txt2Pin),
                    Gst_City = txt2City.Text,
                    Gst_State = txt2State.Text,
                    Gst_Country = txt2Country.Text
                };

                var putTask = client.PutAsJsonAsync<GstinClass>("Gstin/" + Convert.ToInt32(Session["USER_ID"]), gstin);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void EmpEduHome_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP PUT in EmpEduHome table
                var empeduhome = new EmpEduHomeClass()
                {
                    Org_Res_Own = ddl3ResidenceOwnership.SelectedValue,
                    Org_Employment_Nat = ddl3EmploymentNature.SelectedValue,
                    Org_Designation = txt3Designation.Text,
                    Org_Nat = ddl3EmployerNature.SelectedValue + "_" + txt3EmployerNatureOther.Text,
                    Org_Emp_Busi_Nat = ddl3OrganisationNature.SelectedValue + "_" + txt6OrganisationTypeOther.Text,
                    Org_Current_Year = txt3CurrentEmploymentYear.Text,
                    Org_Total_Year = txt3TotalEmploymentYear.Text,
                    Org_Name = txt3OrganisationName.Text,
                    Org_Address = txt3Address.Text,
                    Org_Pin = Convert.ToInt32(txt3PinCode.Text),
                    Org_City = txt3City.Text,
                    Org_State = txt3State.Text,
                    Org_Country = txt3Country.Text,
                    Org_Phone = Convert.ToInt32(txt3Phone.Text),
                    Org_UAN = txt3Uan.Text
                };

                var putTask = client.PutAsJsonAsync<EmpEduHomeClass>("EmpEduHome/" + Convert.ToInt32(Session["USER_ID"]), empeduhome);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void PropHome_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP PUT in PropHome table
                var prophome = new PropHomeClass()
                {
                    Pr_Loan_For = ddl5LoanRequired.SelectedValue,
                    Pr_Amount = Convert.ToDecimal(txt5LoanAmount.Text),
                    Pr_Terms = Convert.ToInt32(txt5Terms.Text),
                    Pr_Loan_Purpose = ddl5LoanPurpose.SelectedValue + "_" + txt5LoanPurpose.Text,
                    Pr_Loan_Prod_Categ = ddl5LoanProductType.SelectedValue + "_" + txt5LoanProductTypeOther.Text,
                    Pr_Repay_Mode = ddl5RepaymentMode.SelectedValue
                };

                var putTask = client.PutAsJsonAsync<PropHomeClass>("PropHome/" + Convert.ToInt32(Session["USER_ID"]), prophome);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void HomeDetails_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP PUT in HomeDetails table
                var homedetails = new HomeDetailsClass()
                {
                    Prop_Type = ddl6PropertyType1.SelectedValue,
                    Prop_Trans_Type = ddl6TransactionType1.SelectedValue,
                    Prop_Builder_Name = txt6BuilderName1.Text,
                    Prop_Project_Name = txt6PropertName1.Text,
                    Prop_Building_Name = txt6BuildingName1.Text,
                    Prop_Land_Area = Convert.ToDecimal(txt6Area1.Text),
                    Prop_Cost = Convert.ToDecimal(txt6PropertyCost1.Text),
                    Prop_Addr = txt6Address1.Text,
                    Prop_Landmark = txt6landmark1.Text,
                    Prop_Pin = Convert.ToInt32(txt6Pin1.Text),
                    Prop_City = txt6City1.Text,
                    Prop_State = txt6State1.Text,
                    Prop_Country = txt6Country1.Text,
                    Prop_Ownership = txt6Ownership1.Text,
                    Prop_Seller_Name = txt6SellerName1.Text,
                    Prop_Seller_Addr = txt6SellerAddress1.Text,
                    Prop_Const_Stage = ddl6ConstructionStage.SelectedValue,
                    Prop_Pur_Con_Cost = Convert.ToDecimal(txt6PurchaseCost.Text),
                    Prop_Reg_Cost = Convert.ToDecimal(txt6RegistratonCost.Text),
                    Prop_Total_Cost = Convert.ToDecimal(txt6TotalCost.Text),
                    Prop_Stamp_Cost = Convert.ToDecimal(txt6StampCost.Text),
                    Prop_Other_Cost = Convert.ToDecimal(txt6OtherCost.Text),
                    Prop_Own_Contrib = Convert.ToDecimal(txt6OwnContribution.Text)
                };

                var putTask = client.PutAsJsonAsync<HomeDetailsClass>("HomeDetails/" + Convert.ToInt32(Session["USER_ID"]), homedetails);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void PropertyDetails_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP PUT in PropertyDetails table
                var propertydetails = new PropertyDetailsClass()
                {
                    Ag_Prop_Type = ddl6PropertyType2.SelectedValue,
                    Ag_Prop_Classif = ddl6PropertyClassification2.SelectedValue,
                    Ag_Building_Age = Convert.ToInt32(txt6BuildingAge2.Text),
                    Ag_Market_Value = Convert.ToDecimal(txt6MarketValue2.Text),
                    Ag_Regis_Value = Convert.ToDecimal(txt6RegisteredValue2.Text),
                    Ag_Prop_Land_Area = Convert.ToDecimal(txt6Area2.Text),
                    Ag_Buildup_Area = Convert.ToDecimal(txt6BuildArea2.Text),
                    Ag_Prop_Addr = txt6Address2.Text,
                    Ag_Landmark = txt6landmark2.Text,
                    Ag_Pin = Convert.ToInt32(txt6Pin2.Text),
                    Ag_City = txt6City2.Text,
                    Ag_State = txt6State2.Text,
                    Ag_Country = txt6Country2.Text,
                    Ag_Rev_Mortage = ddl6ApplicationFor2.SelectedValue,
                    Ag_Lumpsum_Amount = Convert.ToDecimal(txt6LumpsumPlan2.Text),
                    Ag_Annuity_Periodicity = ddl6AnnuityPeriod2.SelectedValue
                };

                var putTask = client.PutAsJsonAsync<PropertyDetailsClass>("PropertyDetails/" + Convert.ToInt32(Session["USER_ID"]), propertydetails);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void Financial_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP PUT in Financial table
                var financial = new FinancialClass()
                {
                    Fin_Status = ddl4FinancialStatus.SelectedValue,
                    Fin_Inc_Gross = Convert.ToDecimal(txt4GrossIncome.Text),
                    Fin_Inc_Net = Convert.ToDecimal(txt4NetIncome.Text),
                    Fin_Inc_Othr = Convert.ToDecimal(txt4OtherIncome.Text),
                    Fin_Inc_Total = Convert.ToDecimal(txt4TotalIncome.Text),
                    Fin_Bank1_Name = txt4Bank1.Text,
                    Fin_Bank1_Branch = txt4Branch1.Text,
                    Fin_Bank1_Ac_Type = txt4AccountType1.Text,
                    Fin_Bank1_Ac_No = txt4AccountNo1.Text,
                    Fin_Bank2_Name = txt4Bank2.Text,
                    Fin_Bank2_Branch = txt4Branch2.Text,
                    Fin_Bank2_Ac_Type = txt4AccountType2.Text,
                    Fin_Bank2_Ac_No = txt4AccountNo2.Text,
                    Fin_Deposits_Inv = Convert.ToDecimal(txt4Deposits.Text),
                    Fin_Shares_Inv = Convert.ToDecimal(txt4Shares.Text),
                    Fin_Insurance_Inv = Convert.ToDecimal(txt4Insurance.Text),
                    Fin_Mutual_Funds_Inv = Convert.ToDecimal(txt4MutualFunds.Text),
                    Fin_Others_Inv = Convert.ToDecimal(txt4Others.Text),
                    Fin_Total_Inv = Convert.ToDecimal(txt4TotalInvestment.Text)
                };

                var putTask = client.PutAsJsonAsync<FinancialClass>("Financial/" + Convert.ToInt32(Session["USER_ID"]), financial);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void Reference_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP PUT in Reference table
                var reference = new ReferenceClass()
                {
                    Ref_Name1 = txt7Name1.Text,
                    Ref_Relat1 = txt7Relation1.Text,
                    Ref_Addr1 = txt7Address1.Text,
                    Ref_Pin1 = Convert.ToInt32(txt7Pin1),
                    Ref_City1 = txt7City1.Text,
                    Ref_State1 = txt7State1.Text,
                    Ref_Country1 = txt7Country1.Text,
                    Ref_Mob_Tel1 = Convert.ToInt64(txt7Mobile1),
                    Ref_Email1 = txt7Email1.Text,
                    Ref_Name2 = txt7Name2.Text,
                    Ref_Relat2 = txt7Relation2.Text,
                    Ref_Addr2 = txt7Address2.Text,
                    Ref_Pin2 = Convert.ToInt32(txt7Pin2),
                    Ref_City2 = txt7City2.Text,
                    Ref_State2 = txt7State2.Text,
                    Ref_Country2 = txt7Country2.Text,
                    Ref_Mob_Tel2 = Convert.ToInt64(txt7Mobile2),
                    Ref_Email2 = txt7Email2.Text
                };

                var putTask = client.PutAsJsonAsync<ReferenceClass>("Reference/" + Convert.ToInt32(Session["USER_ID"]), reference);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void Declar_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                byte[] bytes1 = null;
                if (imageFileUpload.PostedFile != null)
                {
                    HttpPostedFile postedFile1 = imageFileUpload.PostedFile;
                    string doc_File1 = Path.GetFileName(imageFileUpload.PostedFile.FileName);
                    Stream stream1 = postedFile1.InputStream;
                    BinaryReader binaryReader1 = new BinaryReader(stream1);
                    bytes1 = binaryReader1.ReadBytes((int)stream1.Length);

                }

                byte[] bytes2 = null;
                if (signFileUpload.PostedFile != null)
                {
                    HttpPostedFile postedFile2 = signFileUpload.PostedFile;
                    string doc_File2 = Path.GetFileName(signFileUpload.PostedFile.FileName);
                    Stream stream2 = postedFile2.InputStream;
                    BinaryReader binaryReader2 = new BinaryReader(stream2);
                    bytes2 = binaryReader2.ReadBytes((int)stream2.Length);

                }

                //HTTP POST in Declar table
                var declar = new DeclarClass()
                {
                    Dec_Place = txt8Place.Text,
                    Dec_Date = Convert.ToDateTime(txt8DateOfDeclaration),
                    Dec_App_Photo = bytes1,
                    Dec_App_Sign = bytes2
                };

                var putTask = client.PutAsJsonAsync<DeclarClass>("Declar/" + Convert.ToInt32(Session["USER_ID"]), declar);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void HomeAppDoc_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                byte[] bytes1 = null;
                if (imageFileUpload.PostedFile != null)
                {
                    HttpPostedFile postedFile1 = imageFileUpload.PostedFile;
                    string doc_File1 = Path.GetFileName(imageFileUpload.PostedFile.FileName);
                    Stream stream1 = postedFile1.InputStream;
                    BinaryReader binaryReader1 = new BinaryReader(stream1);
                    bytes1 = binaryReader1.ReadBytes((int)stream1.Length);

                }

                //HTTP PUT in PersonalAppDoc table
                var personalappdoc = new PersonalAppDocClass()
                {
                    Doc1_Name = ddl8Identity.SelectedValue,
                    Doc1 = bytes1,
                    Doc1_Status = "Pending"
                };

                var putTask = client.PutAsJsonAsync<PersonalAppDocClass>("PersonalAppDoc/" + Convert.ToInt32(Session["USER_ID"]), personalappdoc);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        //ID Generator
        public string GenerateID()
        {
            string format = "Mddyyyyhhmmss";
            string datename = String.Format("{0}PER", DateTime.Now.ToString(format));

            Random ran = new Random();

            string PersID = "LT" + ran.Next(100, 999) + datename;

            return PersID;
        }

        //EMI Calculation
        public void Emi_Calculation_Method()
        {
            double p = Convert.ToDouble(txt5LoanAmount.Text);
            double ra;

            if (p <= 3000000)
            {
                ra = Convert.ToDouble(PerRate1);
            }
            else if(p < 7000000)
            {
                ra = Convert.ToDouble(PerRate2);
            }
            else
            {
                ra = Convert.ToDouble(PerRate3);
            }

            int t = Convert.ToInt32(txt5Terms.Text);
            ra = ra / (12 * 100);

            emi = (p * ra * Math.Pow(1 + ra, t)) / ((Math.Pow(1 + ra, t)) - 1);

            double ori = emi;
            emi = Math.Round(emi, 2);

            var tAmt = t * emi;
            var totalAmt = t * ori;
            totalAmt = Math.Round(totalAmt, 2);
            var balance = totalAmt - tAmt;
            lastEmi = emi + balance;
            interestAmt = totalAmt - p;
        }
    }
}