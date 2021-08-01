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
    public partial class EducationLoanDetails : System.Web.UI.Page
    {
        string PerRate;
        double emi, lastEmi, interestAmt;

        protected void Page_Load(object sender, EventArgs e)
        {
            string tps = Convert.ToString(Session["Education_Rate"]);
            var tp = tps.Split('%');
            PerRate = tp[0];

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

                        if (edit.Home_Status == "Pending")
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

        protected void submit6_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //GET Request LoanAppliedDetails by id
                var rT = client.GetAsync("LoanAppliedDetails/" + Convert.ToInt32(Session["USER_ID"]));
                rT.Wait();

                var r = rT.Result;
                if (r.IsSuccessStatusCode)
                {
                    //PUT methods calling
                    Personal_Put_Id();
                    Gstin_Put_Id();
                    Nri_Put_Id();
                    EduCourse_Put_Id();
                    LoanEdu_Put_Id();
                    EmpEduHome_Put_Id();
                    Financial_Put_Id();
                    Reference_Put_Id();
                    Declar_Put_Id();
                    EduAppDoc_Put_Id();
                }
                else
                {
                    //POST method calling
                    Personal_Post();
                    Gstin_Post();
                    Nri_Post();
                    EduCourse_Post();
                    LoanEdu_Post();
                    EmpEduHome_Post();
                    Financial_Post();
                    Reference_Post();
                    Declar_Post();
                    EduAppDoc_Post();

                    Emi_Calculation_Method();

                    lblApp_ID.Text = GenerateID();
                    LoanAppliedDetailsEducation_Post();
                    StatusEducation_Post();

                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "successAlert()", true);
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

                    var app_name = personal.App_Name.Split(' ');
                    var app_fath_spou_name = personal.App_Fath_Spou_Name.Split(' ');
                    var app_mother_name = personal.App_Mother_Name.Split(' ');
                    var app_religion = personal.App_Religion.Split(' ');
                    var app_category = personal.App_Category.Split(' ');
                    var app_education = personal.App_Education.Split(' ');

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

        public void Nri_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("Nri/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<NriClass>();
                    readTask.Wait();

                    var nri = readTask.Result;

                    txt3CountryName.Text = nri.Nri_Country_Name;
                    txt3CountryCode.Text = Convert.ToString(nri.Nri_Country_Code);
                    ddl31TaxOutsideIndia.SelectedValue = nri.Nri_Tax_Resid;
                    txt3JurisdictionResidence.Text = nri.Nri_Jurid_Resid;
                    txt3Tin.Text = nri.Nri_Tin;
                    txt3BirthCountry.Text = nri.Nri_Birth_Country;
                    txt3BirthCity.Text = nri.Nri_Birth_City;
                    txt3JurisdictionAddress.Text = nri.Nri_Jur_Addr;
                    txt3JurisdictionCity.Text = nri.Nri_City;
                    txt3JurisdictionState.Text = nri.Nri_State;
                    txt3PostCode.Text = Convert.ToString(nri.Nri_Zip_Post_Code);
                    txt3IsoCode.Text = Convert.ToString(nri.Nri_Iso);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void EduCourse_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("EduCourse/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EduCourseClass>();
                    readTask.Wait();

                    var educourse = readTask.Result;

                    var stcourseappr = educourse.St_Course_Appr.Split('_');
                    var stcoursecat = educourse.St_Course_Cat.Split('_');
                    var sttotalmorat = educourse.St_Total_Morat.Split('_');

                    txt4SscInstitute.Text = educourse.St_Ssc_Inst;
                    txt4SscYear.Text = educourse.St_Ssc_Year;
                    txt4SscPercentage.Text = educourse.St_Ssc_Per;
                    txt4SscClassObtained.Text = educourse.St_Ssc_Class;
                    txt4SscScholarship.Text = educourse.St_Ssc_Money_Won;
                    txt4HscInstitute.Text = educourse.St_Hsc_Inst;
                    txt4HscYear.Text = educourse.St_Hsc_Year;
                    txt4HscPercentage.Text = educourse.St_Hsc_Per;
                    txt4HscClassObtained.Text = educourse.St_Hsc_Class;
                    txt4HscScholarship.Text = educourse.St_Hsc_Money_Won;
                    txt4LdInstitute.Text = educourse.St_LD_Inst;
                    txt4LdYear.Text = educourse.St_LD_Year;
                    txt4LdPercentage.Text = educourse.St_LD_Per;
                    txt4LdClassObtained.Text = educourse.St_LD_Class;
                    txt4LdScholarship.Text = educourse.St_LD_Money_Won;
                    txt4ExamScore.Text = educourse.St_Exam_Score;
                    txt4CollegeAddress.Text = educourse.St_College_Details;
                    txt4CollegeCity.Text = educourse.St_City;
                    txt4CollegeState.Text = educourse.St_State;
                    txt4CollegeDistrict.Text = educourse.St_District;
                    txt4CollegePin.Text = educourse.St_Pin_Code;
                    txt4CollegeCountry.Text = educourse.St_Country;
                    ddl4AdmissionStatus.SelectedValue = educourse.St_Admission_Status;
                    txt4UniversityName.Text = educourse.St_Univ_Name;
                    txt4UniversityPerson.Text = educourse.St_Univ_Person;
                    txt4CourseName.Text = educourse.St_Course_Name;
                    ddl4CourseApproved.SelectedValue = stcourseappr[0];
                    txt4CourseApprovedOther.Text = stcourseappr[1];
                    ddl4AdmissionEntrance.SelectedValue = educourse.St_Admsn;
                    ddl4CourseCategory.SelectedValue = stcoursecat[0];
                    txt4CourseCategoryOther.Text = stcoursecat[1];
                    ddl4CourseType.SelectedValue = educourse.St_Course_Type;
                    txt4CourseStart.Text = educourse.St_Course_Start;
                    txt4CourseEnd.Text = educourse.St_Course_End;
                    ddl4A.SelectedValue = educourse.St_Morat1;
                    ddl4B.SelectedValue = educourse.St_Morat2;
                    ddl4C.SelectedValue = sttotalmorat[0];
                    txt4C.Text = sttotalmorat[1];
                    ddl4D.SelectedValue = educourse.St_Emi_Repay;
                    txt4E.Text = educourse.St_Loan_Period;
                    ddl4Servicing.SelectedValue = educourse.St_Int_Serv;
                    txt4ExpectedIncome.Text = educourse.St_Exp_Income;
                    txt4InstituteName.Text = educourse.St_Clg_Name;
                    txt4CoursePursued.Text = educourse.St_Course_Persuid;
                    txt4CourseCompletion.Text = educourse.St_Compl_Date;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void LoanEdu_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("LoanEdu/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<LoanEduClass>();
                    readTask.Wait();

                    var loanedu = readTask.Result;

                    txt5TutionFees.Text = Convert.ToString(loanedu.Edu_Tut_Fees);
                    txt5LivingExpenses.Text = Convert.ToString(loanedu.Edu_Living_Expen);
                    txt5TravelingExpenses.Text = Convert.ToString(loanedu.Edu_Travel_Expen);
                    txt5OtherExpenses.Text = Convert.ToString(loanedu.Edu_Other_Expen);
                    txt5TotalExpenses.Text = Convert.ToString(loanedu.Edu_Total_Expen);
                    txt5OwnSource.Text = Convert.ToString(loanedu.Edu_Own_Inc);
                    txt5Scholarship.Text = Convert.ToString(loanedu.Edu_Scholar_Inc);
                    txt5Others.Text = Convert.ToString(loanedu.Edu_Other_Inc);
                    txt5LoanRequired.Text = Convert.ToString(loanedu.Edu_Loan_Required);
                    ddl5DisbursementDetails.SelectedValue = loanedu.Edu_Disburs_Details;
                    ddl5Mode.SelectedValue = loanedu.Edu_Mode;
                    txt5DdInFavour.Text = loanedu.Edu_Dd_In_Favour_Of;
                    txt5Payable.Text = loanedu.Edu_Payable_At_For;
                    txt5Amount.Text = Convert.ToString(loanedu.Edu_DD_Amount);
                    txt5TtSwiftCode.Text = loanedu.Edu_Tt_Swift_Code;
                    txt5RtgsNeft.Text = loanedu.Edu_Rtgs_Neft;
                    txt5UniversityAccount.Text = loanedu.Edu_University_Ac;
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

                    var org_nat = empeduhome.Org_Nat.Split(' ');

                    ddl6EmploymentType.SelectedValue = empeduhome.Org_Employment_Nat;
                    ddl6OrganisationType.SelectedValue = org_nat[0];
                    txt6OrganisationTypeOther.Text = org_nat[1];
                    txt6EmployerName.Text = empeduhome.Org_Name;
                    txt6OfficeAddress.Text = empeduhome.Org_Address;
                    txt6City.Text = empeduhome.Org_City;
                    txt6State.Text = empeduhome.Org_State;
                    txt6PinCode.Text = Convert.ToString(empeduhome.Org_Pin);
                    txt6Telephone.Text = Convert.ToString(empeduhome.Org_Phone);
                    txt6Designation.Text = empeduhome.Org_Designation;
                    txt6EmploymentYears.Text = empeduhome.Org_Total_Year;
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

                    ddl7EmploymentType.SelectedValue = financial.Fin_Status;
                    txt7GrossIncome.Text = Convert.ToString(financial.Fin_Inc_Gross);
                    txt7NetIncome.Text = Convert.ToString(financial.Fin_Inc_Net);
                    txt7OtherIncome.Text = Convert.ToString(financial.Fin_Inc_Othr);
                    txt7TotalIncome.Text = Convert.ToString(financial.Fin_Inc_Total);
                    txt7Bank1.Text = financial.Fin_Bank1_Name;
                    txt7Branch1.Text = financial.Fin_Bank1_Branch;
                    txt7AccountType1.Text = financial.Fin_Bank1_Ac_Type;
                    txt7AccountNo1.Text = financial.Fin_Bank1_Ac_No;
                    txt7Bank2.Text = financial.Fin_Bank2_Name;
                    txt7Branch2.Text = financial.Fin_Bank2_Branch;
                    txt7AccountType2.Text = financial.Fin_Bank2_Ac_Type;
                    txt7AccountNo2.Text = financial.Fin_Bank2_Ac_No;
                    txt7TotalInvestment.Text = Convert.ToString(financial.Fin_Total_Inv);
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

                    txt8Name1.Text = reference.Ref_Name1;
                    txt8Relation1.Text = reference.Ref_Relat1;
                    txt8Address1.Text = reference.Ref_Addr1;
                    txt8Pin1.Text = Convert.ToString(reference.Ref_Pin1);
                    txt8City1.Text = reference.Ref_City1;
                    txt8State1.Text = reference.Ref_State1;
                    txt8Country1.Text = reference.Ref_Country1;
                    txt8Mobile1.Text = Convert.ToString(reference.Ref_Mob_Tel1);
                    txt8Email1.Text = reference.Ref_Email1;
                    txt8Name2.Text = reference.Ref_Name2;
                    txt8Relation2.Text = reference.Ref_Relat2;
                    txt8Address2.Text = reference.Ref_Addr2;
                    txt8Pin2.Text = Convert.ToString(reference.Ref_Pin2);
                    txt8City2.Text = reference.Ref_City2;
                    txt8State2.Text = reference.Ref_State2;
                    txt8Country2.Text = reference.Ref_Country2;
                    txt8Mobile2.Text = Convert.ToString(reference.Ref_Mob_Tel2);
                    txt8Email2.Text = reference.Ref_Email2;
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

                    txt9Place.Text = declare.Dec_Place;
                    txt9DateOfDeclaration.Text = Convert.ToString(declare.Dec_Date);
                    //output_image.ImageUrl = "data:Image/jpeg;base64," + str1Base64;
                    //output_sign.ImageUrl = "data:Image/jpeg;base64," + str2Base64;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void EduAppDoc_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("EduAppDoc/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EduAppDocClass>();
                    readTask.Wait();

                    var eduappdoc = readTask.Result;

                    if (eduappdoc.Doc1 != null)
                    {
                        RequiredFieldValidator22.Enabled = false;
                        RequiredFieldValidator34.Enabled = false;
                        RequiredFieldValidator23.Enabled = false;
                        RequiredFieldValidator33.Enabled = false;
                        RequiredFieldValidator24.Enabled = false;
                        RequiredFieldValidator32.Enabled = false;
                        RequiredFieldValidator25.Enabled = false;
                        RequiredFieldValidator31.Enabled = false;
                        RequiredFieldValidator41.Enabled = false;
                        RequiredFieldValidator50.Enabled = false;
                        RequiredFieldValidator26.Enabled = false;
                        RequiredFieldValidator29.Enabled = false;
                        RequiredFieldValidator27.Enabled = false;
                        RequiredFieldValidator28.Enabled = false;

                        lbl9Identity.Text = "Submitted";
                        lbl9Residence.Text = "Submitted";
                        lbl9Financial.Text = "Submitted";
                        lbl9AdmissionLetter.Text = "Submitted";
                        lbl9DemandLetter.Text = "Submitted";
                        lbl9SscMarkSheet.Text = "Submitted";
                        lbl9HscMarkSheet.Text = "Submitted";
                        lbl9LastDegree.Text = "Submitted";
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
                    App_Ckyc_No = txt1CKYC.Text,
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
                    App_Off_Email = txt1OfficialEmail.Text,
                    App_Telephone = Convert.ToInt64(txt1Telephone.Text),
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

                //HTTP POST in Gstin table
                var gstin = new GstinClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Gst_Reg = ddl21UnderGst.SelectedValue,
                    Gst_Exem = ddl22GstExemption.SelectedValue,
                    Gst_Exem_Reason = txt2ExemptionReason.Text,
                    Gst_Exem_date = Convert.ToDateTime(txt2ExemptionValid.Text),
                    Gst_Reg_Date = Convert.ToDateTime(txt2GstinDate.Text),
                    Gst_Reg_Type = ddl2GstType.SelectedValue,
                    Gst_Eco_Zone = txt2GstZone.Text,
                    Gst_default = txt2GstinDefault.Text,
                    Gstin_Addr = txt2GstinAddress.Text,
                    Gst_Pin = Convert.ToInt32(txt2Pin.Text),
                    Gst_City = txt2City.Text,
                    Gst_State = txt2State.Text,
                    Gst_Country = txt2Country.Text
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

        public void Nri_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in Nri table
                var nri = new NriClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Nri_Country_Name = txt3CountryName.Text,
                    Nri_Country_Code = Convert.ToInt32(txt3CountryCode.Text),
                    Nri_Tax_Resid = ddl31TaxOutsideIndia.SelectedValue,
                    Nri_Jurid_Resid = txt3JurisdictionResidence.Text,
                    Nri_Tin = txt3Tin.Text,
                    Nri_Birth_Country = txt3BirthCountry.Text,
                    Nri_Birth_City = txt3BirthCity.Text,
                    Nri_Jur_Addr = txt3JurisdictionAddress.Text,
                    Nri_City = txt3JurisdictionCity.Text,
                    Nri_State = txt3JurisdictionState.Text,
                    Nri_Zip_Post_Code = Convert.ToInt32(txt3PostCode.Text),
                    Nri_Iso = Convert.ToInt32(txt3IsoCode.Text)
                };

                var postTask = client.PostAsJsonAsync<NriClass>("Nri", nri);
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

        public void EduCourse_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in EduCourse table
                var educourse = new EduCourseClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    St_Ssc_Inst = txt4SscInstitute.Text,
                    St_Ssc_Year = txt4SscYear.Text,
                    St_Ssc_Per = txt4SscPercentage.Text,
                    St_Ssc_Class = txt4SscClassObtained.Text,
                    St_Ssc_Money_Won = txt4SscScholarship.Text,
                    St_Hsc_Inst = txt4HscInstitute.Text,
                    St_Hsc_Year = txt4HscYear.Text,
                    St_Hsc_Per = txt4HscPercentage.Text,
                    St_Hsc_Class = txt4HscClassObtained.Text,
                    St_Hsc_Money_Won = txt4HscScholarship.Text,
                    St_LD_Inst = txt4LdInstitute.Text,
                    St_LD_Year = txt4LdYear.Text,
                    St_LD_Per = txt4LdPercentage.Text,
                    St_LD_Class = txt4LdClassObtained.Text,
                    St_LD_Money_Won = txt4LdScholarship.Text,
                    St_Exam_Score = txt4ExamScore.Text,
                    St_College_Details = txt4CollegeAddress.Text,
                    St_City = txt4CollegeCity.Text,
                    St_State = txt4CollegeState.Text,
                    St_District = txt4CollegeDistrict.Text,
                    St_Pin_Code = txt4CollegePin.Text,
                    St_Country = txt4CollegeCountry.Text,
                    St_Admission_Status = ddl4AdmissionStatus.SelectedValue,
                    St_Univ_Name = txt4UniversityName.Text,
                    St_Univ_Person = txt4UniversityPerson.Text,
                    St_Course_Name = txt4CourseName.Text,
                    St_Course_Appr = ddl4CourseApproved.SelectedValue + "_" + txt4CourseApprovedOther.Text,
                    St_Admsn = ddl4AdmissionEntrance.SelectedValue,
                    St_Course_Cat = ddl4CourseCategory.SelectedValue + "_" + txt4CourseCategoryOther.Text,
                    St_Course_Type = ddl4CourseType.SelectedValue,
                    St_Course_Start = txt4CourseStart.Text,
                    St_Course_End = txt4CourseEnd.Text,
                    St_Morat1 = ddl4A.SelectedValue,
                    St_Morat2 = ddl4B.SelectedValue,
                    St_Total_Morat = ddl4C.SelectedValue + "_" + txt4C.Text,
                    St_Emi_Repay = ddl4D.SelectedValue,
                    St_Loan_Period = txt4E.Text,
                    St_Int_Serv = ddl4Servicing.SelectedValue,
                    St_Exp_Income = txt4ExpectedIncome.Text,
                    St_Clg_Name = txt4InstituteName.Text,
                    St_Course_Persuid = txt4CoursePursued.Text,
                    St_Compl_Date = txt4CourseCompletion.Text
                };

                var postTask = client.PostAsJsonAsync<EduCourseClass>("EduCourse", educourse);
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

        public void LoanEdu_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in LoanEdu table
                var loanedu = new LoanEduClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Edu_Tut_Fees = Convert.ToDecimal(txt5TutionFees.Text),
                    Edu_Living_Expen = Convert.ToDecimal(txt5LivingExpenses.Text),
                    Edu_Travel_Expen = Convert.ToDecimal(txt5TravelingExpenses.Text),
                    Edu_Other_Expen = Convert.ToDecimal(txt5OtherExpenses.Text),
                    Edu_Total_Expen = Convert.ToDecimal(txt5TotalExpenses.Text),
                    Edu_Own_Inc = Convert.ToDecimal(txt5OwnSource.Text),
                    Edu_Scholar_Inc = Convert.ToDecimal(txt5Scholarship.Text),
                    Edu_Other_Inc = Convert.ToDecimal(txt5Others.Text),
                    Edu_Loan_Required = Convert.ToDecimal(txt5LoanRequired.Text),
                    Edu_Disburs_Details = ddl5DisbursementDetails.SelectedValue,
                    Edu_Mode = ddl5Mode.SelectedValue,
                    Edu_Dd_In_Favour_Of = txt5DdInFavour.Text,
                    Edu_Payable_At_For = txt5Payable.Text,
                    Edu_DD_Amount = Convert.ToDecimal(txt5Amount.Text),
                    Edu_Tt_Swift_Code = txt5TtSwiftCode.Text,
                    Edu_Rtgs_Neft = txt5RtgsNeft.Text,
                    Edu_University_Ac = txt5UniversityAccount.Text
            };

                var postTask = client.PostAsJsonAsync<LoanEduClass>("LoanEdu", loanedu);
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
                EmpEduHomeClass empeduhome = new EmpEduHomeClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Org_Res_Own = null,
                    Org_Employment_Nat = ddl6EmploymentType.SelectedValue,
                    Org_Nat = ddl6OrganisationType.SelectedValue + "_" + txt6OrganisationTypeOther.Text,
                    Org_Emp_Busi_Nat = null,
                    Org_Designation = txt6Designation.Text,
                    Org_Current_Year = txt6EmploymentYears.Text,
                    Org_Total_Year = txt6EmploymentYears.Text,
                    Org_Name = txt6EmployerName.Text,
                    Org_Address = txt6OfficeAddress.Text,
                    Org_Pin = Convert.ToInt32(txt6PinCode.Text),
                    Org_City = txt6City.Text,
                    Org_State = txt6State.Text,
                    Org_Country = txt6Telephone.Text,
                    Org_Phone = Convert.ToInt64(txt6Telephone.Text),
                    Org_UAN = null
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

        public void Financial_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in Financial table
                var financial = new FinancialClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Fin_Status = ddl7EmploymentType.SelectedValue,
                    Fin_Inc_Gross = Convert.ToDecimal(txt7GrossIncome.Text),
                    Fin_Inc_Net = Convert.ToDecimal(txt7NetIncome.Text),
                    Fin_Inc_Othr = Convert.ToDecimal(txt7OtherIncome.Text),
                    Fin_Inc_Total = Convert.ToDecimal(txt7TotalIncome.Text),
                    Fin_Bank1_Name = txt7Bank1.Text,
                    Fin_Bank1_Branch = txt7Branch1.Text,
                    Fin_Bank1_Ac_Type = txt7AccountType1.Text,
                    Fin_Bank1_Ac_No = txt7AccountNo1.Text,
                    Fin_Bank2_Name = txt7Bank2.Text,
                    Fin_Bank2_Branch = txt7Branch2.Text,
                    Fin_Bank2_Ac_Type = txt7AccountType2.Text,
                    Fin_Bank2_Ac_No = txt7AccountNo2.Text,
                    Fin_Deposits_Inv = 0,
                    Fin_Shares_Inv = 0,
                    Fin_Insurance_Inv = 0,
                    Fin_Mutual_Funds_Inv = 0,
                    Fin_Others_Inv = 0,
                    Fin_Total_Inv = Convert.ToDecimal(txt7TotalInvestment.Text)
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
                var reference = new ReferenceClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Ref_Name1 = txt8Name1.Text,
                    Ref_Relat1 = txt8Relation1.Text,
                    Ref_Addr1 = txt8Address1.Text,
                    Ref_Pin1 = Convert.ToInt32(txt8Pin1.Text),
                    Ref_City1 = txt8City1.Text,
                    Ref_State1 = txt8State1.Text,
                    Ref_Country1 = txt8Country1.Text,
                    Ref_Mob_Tel1 = Convert.ToInt64(txt8Mobile1.Text),
                    Ref_Email1 = txt8Email1.Text,
                    Ref_Name2 = txt8Name2.Text,
                    Ref_Relat2 = txt8Relation2.Text,
                    Ref_Addr2 = txt8Address2.Text,
                    Ref_Pin2 = Convert.ToInt32(txt8Pin2.Text),
                    Ref_City2 = txt8City2.Text,
                    Ref_State2 = txt8State2.Text,
                    Ref_Country2 = txt8Country2.Text,
                    Ref_Mob_Tel2 = Convert.ToInt64(txt8Mobile2.Text),
                    Ref_Email2 = txt8Email2.Text
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
                    Dec_Place = txt9Place.Text,
                    Dec_Date = Convert.ToDateTime(txt9DateOfDeclaration.Text),
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

        public void EduAppDoc_Post()
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
                if (AdmissionLetterFileUpload.PostedFile != null)
                {
                    HttpPostedFile postedFile4 = AdmissionLetterFileUpload.PostedFile;
                    string doc_File4 = Path.GetFileName(AdmissionLetterFileUpload.PostedFile.FileName);
                    Stream stream4 = postedFile4.InputStream;
                    BinaryReader binaryReader4 = new BinaryReader(stream4);
                    bytes4 = binaryReader4.ReadBytes((int)stream4.Length);

                }

                byte[] bytes5 = null;
                if (DemandLetterFileUpload.PostedFile != null)
                {
                    HttpPostedFile postedFile5 = DemandLetterFileUpload.PostedFile;
                    string doc_File5 = Path.GetFileName(DemandLetterFileUpload.PostedFile.FileName);
                    Stream stream5 = postedFile5.InputStream;
                    BinaryReader binaryReader5 = new BinaryReader(stream5);
                    bytes5 = binaryReader5.ReadBytes((int)stream5.Length);

                }

                byte[] bytes6 = null;
                if (SscMarkSheetFileUpload.PostedFile != null)
                {
                    HttpPostedFile postedFile6 = SscMarkSheetFileUpload.PostedFile;
                    string doc_File6 = Path.GetFileName(SscMarkSheetFileUpload.PostedFile.FileName);
                    Stream stream6 = postedFile6.InputStream;
                    BinaryReader binaryReader6 = new BinaryReader(stream6);
                    bytes6 = binaryReader6.ReadBytes((int)stream6.Length);

                }

                byte[] bytes7 = null;
                if (HscMarkSheetFileUpload.PostedFile != null)
                {
                    HttpPostedFile postedFile7 = HscMarkSheetFileUpload.PostedFile;
                    string doc_File7 = Path.GetFileName(HscMarkSheetFileUpload.PostedFile.FileName);
                    Stream stream7 = postedFile7.InputStream;
                    BinaryReader binaryReader7 = new BinaryReader(stream7);
                    bytes7 = binaryReader7.ReadBytes((int)stream7.Length);

                }

                byte[] bytes8 = null;
                if (LastDegreeFileUpload.PostedFile != null)
                {
                    HttpPostedFile postedFile8 = LastDegreeFileUpload.PostedFile;
                    string doc_File8 = Path.GetFileName(LastDegreeFileUpload.PostedFile.FileName);
                    Stream stream8 = postedFile8.InputStream;
                    BinaryReader binaryReader8 = new BinaryReader(stream8);
                    bytes8 = binaryReader8.ReadBytes((int)stream8.Length);

                }

                //HTTP POST in EduAppDoc table
                var eduappdoc = new EduAppDocClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Doc1_Name = ddl9Identity.SelectedValue,
                    Doc1 = bytes1,
                    Doc1_Status = "Pending",
                    Doc2_Name = ddl9Residence.SelectedValue,
                    Doc2 = bytes2,
                    Doc2_Status = "Pending",
                    Doc3_Name = ddl9Financial.SelectedValue,
                    Doc3 = bytes1,
                    Doc3_Status = "Pending",
                    Doc4_Name = ddl9AdmissionLetter.SelectedValue,
                    Doc4 = bytes1,
                    Doc4_Status = "Pending",
                    Doc5_Name = ddl9DemandLetter.SelectedValue,
                    Doc5 = bytes1,
                    Doc5_Status = "Pending",
                    Doc6_Name = ddl9SscMarkSheet.SelectedValue,
                    Doc6 = bytes1,
                    Doc6_Status = "Pending",
                    Doc7_Name = ddl9HscMarkSheet.SelectedValue,
                    Doc7 = bytes1,
                    Doc7_Status = "Pending",
                    Doc8_Name = ddl9LastDegree.SelectedValue,
                    Doc8 = bytes1,
                    Doc8_Status = "Pending",
                };

                var postTask = client.PostAsJsonAsync<EduAppDocClass>("EduAppDoc", eduappdoc);
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

        public void LoanAppliedDetailsEducation_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in LoanAppliedDetails table
                var ladp = new LoanAppliedDetailsEducationClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Edu_ID = lblApp_ID.Text,
                    Edu_Amount = Convert.ToDecimal(txt5LoanRequired.Text),
                    Edu_Rate = Convert.ToDecimal(PerRate),
                    Edu_Tenure = Convert.ToInt32(txt4E.Text),
                    Edu_Emi = Convert.ToDecimal(emi),
                    Edu_Last_Emi = Convert.ToDecimal(lastEmi),
                    Edu_Interest = Convert.ToDecimal(interestAmt)
                };

                var postTask = client.PostAsJsonAsync<LoanAppliedDetailsEducationClass>("LoanAppliedDetailsEducation", ladp);
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

        public void StatusEducation_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in Status table
                var sp = new StatusEducationClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Education_Applied = "Yes",
                    Education_Status = "Pending",
                    Education_Correction = "NA"
                };

                var postTask = client.PostAsJsonAsync<StatusEducationClass>("StatusEducation", sp);
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

        public void Nri_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP PUT in Nri table
                var nri = new NriClass()
                {
                    Nri_Country_Name = txt3CountryName.Text,
                    Nri_Country_Code = Convert.ToInt32(txt3CountryCode.Text),
                    Nri_Tax_Resid = ddl31TaxOutsideIndia.SelectedValue,
                    Nri_Jurid_Resid = txt3JurisdictionResidence.Text,
                    Nri_Tin = txt3Tin.Text,
                    Nri_Birth_Country = txt3BirthCountry.Text,
                    Nri_Birth_City = txt3BirthCity.Text,
                    Nri_Jur_Addr = txt3JurisdictionAddress.Text,
                    Nri_City = txt3JurisdictionCity.Text,
                    Nri_State = txt3JurisdictionState.Text,
                    Nri_Zip_Post_Code = Convert.ToInt32(txt3PostCode.Text),
                    Nri_Iso = Convert.ToInt32(txt3IsoCode.Text)
                };

                var putTask = client.PutAsJsonAsync<NriClass>("Nri/" + Convert.ToInt32(Session["USER_ID"]), nri);
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

        public void EduCourse_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP PUT in EduCourse table
                var educourse = new EduCourseClass()
                {
                    St_Ssc_Inst = txt4SscInstitute.Text,
                    St_Ssc_Year = txt4SscYear.Text,
                    St_Ssc_Per = txt4SscPercentage.Text,
                    St_Ssc_Class = txt4SscClassObtained.Text,
                    St_Ssc_Money_Won = txt4SscScholarship.Text,
                    St_Hsc_Inst = txt4HscInstitute.Text,
                    St_Hsc_Year = txt4HscYear.Text,
                    St_Hsc_Per = txt4HscPercentage.Text,
                    St_Hsc_Class = txt4HscClassObtained.Text,
                    St_Hsc_Money_Won = txt4HscScholarship.Text,
                    St_LD_Inst = txt4LdInstitute.Text,
                    St_LD_Year = txt4LdYear.Text,
                    St_LD_Per = txt4LdPercentage.Text,
                    St_LD_Class = txt4LdClassObtained.Text,
                    St_LD_Money_Won = txt4LdScholarship.Text,
                    St_Exam_Score = txt4ExamScore.Text,
                    St_College_Details = txt4CollegeAddress.Text,
                    St_City = txt4CollegeCity.Text,
                    St_State = txt4CollegeState.Text,
                    St_District = txt4CollegeDistrict.Text,
                    St_Pin_Code = txt4CollegePin.Text,
                    St_Country = txt4CollegeCountry.Text,
                    St_Admission_Status = ddl4AdmissionStatus.SelectedValue,
                    St_Univ_Name = txt4UniversityName.Text,
                    St_Univ_Person = txt4UniversityPerson.Text,
                    St_Course_Name = txt4CourseName.Text,
                    St_Course_Appr = ddl4CourseApproved.SelectedValue + "_" + txt4CourseApprovedOther.Text,
                    St_Admsn = ddl4AdmissionEntrance.SelectedValue,
                    St_Course_Cat = ddl4CourseCategory.SelectedValue + "_" + txt4CourseCategoryOther.Text,
                    St_Course_Type = ddl4CourseType.SelectedValue,
                    St_Course_Start = txt4CourseStart.Text,
                    St_Course_End = txt4CourseEnd.Text,
                    St_Morat1 = ddl4A.SelectedValue,
                    St_Morat2 = ddl4B.SelectedValue,
                    St_Total_Morat = ddl4C.SelectedValue + "_" + txt4C.Text,
                    St_Emi_Repay = ddl4D.SelectedValue,
                    St_Loan_Period = txt4E.Text,
                    St_Int_Serv = ddl4Servicing.SelectedValue,
                    St_Exp_Income = txt4ExpectedIncome.Text,
                    St_Clg_Name = txt4InstituteName.Text,
                    St_Course_Persuid = txt4CoursePursued.Text,
                    St_Compl_Date = txt4CourseCompletion.Text
                };

                var putTask = client.PutAsJsonAsync<EduCourseClass>("EduCourse/" + Convert.ToInt32(Session["USER_ID"]), educourse);
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

        public void LoanEdu_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP PUT in LoanEdu table
                var loanedu = new LoanEduClass()
                {
                    Edu_Tut_Fees = Convert.ToDecimal(txt5TutionFees.Text),
                    Edu_Living_Expen = Convert.ToDecimal(txt5LivingExpenses.Text),
                    Edu_Travel_Expen = Convert.ToDecimal(txt5TravelingExpenses.Text),
                    Edu_Other_Expen = Convert.ToDecimal(txt5OtherExpenses.Text),
                    Edu_Total_Expen = Convert.ToDecimal(txt5TotalExpenses.Text),
                    Edu_Own_Inc = Convert.ToDecimal(txt5OwnSource.Text),
                    Edu_Scholar_Inc = Convert.ToDecimal(txt5Scholarship.Text),
                    Edu_Other_Inc = Convert.ToDecimal(txt5Others.Text),
                    Edu_Loan_Required = Convert.ToDecimal(txt5LoanRequired.Text),
                    Edu_Disburs_Details = ddl5DisbursementDetails.SelectedValue,
                    Edu_Mode = ddl5Mode.SelectedValue,
                    Edu_Dd_In_Favour_Of = txt5DdInFavour.Text,
                    Edu_Payable_At_For = txt5Payable.Text,
                    Edu_DD_Amount = Convert.ToDecimal(txt5Amount.Text),
                    Edu_Tt_Swift_Code = txt5TtSwiftCode.Text,
                    Edu_Rtgs_Neft = txt5RtgsNeft.Text,
                    Edu_University_Ac = txt5UniversityAccount.Text
                };

                var putTask = client.PutAsJsonAsync<LoanEduClass>("LoanEdu/" + Convert.ToInt32(Session["USER_ID"]), loanedu);
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
                    Org_Res_Own = null,
                    Org_Employment_Nat = ddl6EmploymentType.SelectedValue,
                    Org_Nat = ddl6OrganisationType.SelectedValue + txt6OrganisationTypeOther.Text,
                    Org_Emp_Busi_Nat = null,
                    Org_Designation = txt6Designation.Text,
                    Org_Current_Year = txt6EmploymentYears.Text,
                    Org_Total_Year = txt6EmploymentYears.Text,
                    Org_Name = txt6EmployerName.Text,
                    Org_Address = txt6OfficeAddress.Text,
                    Org_Pin = Convert.ToInt32(txt6PinCode),
                    Org_City = txt6City.Text,
                    Org_State = txt6State.Text,
                    Org_Country = txt6Telephone.Text,
                    Org_Phone = Convert.ToInt32(txt6Telephone),
                    Org_UAN = null
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

        public void Financial_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP PUT in Financial table
                var financial = new FinancialClass()
                {
                    Fin_Status = ddl7EmploymentType.SelectedValue,
                    Fin_Inc_Gross = Convert.ToDecimal(txt7GrossIncome),
                    Fin_Inc_Net = Convert.ToDecimal(txt7NetIncome),
                    Fin_Inc_Othr = Convert.ToDecimal(txt7OtherIncome),
                    Fin_Inc_Total = Convert.ToDecimal(txt7TotalIncome),
                    Fin_Bank1_Name = txt7Bank1.Text,
                    Fin_Bank1_Branch = txt7Branch1.Text,
                    Fin_Bank1_Ac_Type = txt7AccountType1.Text,
                    Fin_Bank1_Ac_No = txt7AccountNo1.Text,
                    Fin_Bank2_Name = txt7Bank2.Text,
                    Fin_Bank2_Branch = txt7Branch2.Text,
                    Fin_Bank2_Ac_Type = txt7AccountType2.Text,
                    Fin_Bank2_Ac_No = txt7AccountNo2.Text,
                    Fin_Deposits_Inv = 0,
                    Fin_Shares_Inv = 0,
                    Fin_Insurance_Inv = 0,
                    Fin_Mutual_Funds_Inv = 0,
                    Fin_Others_Inv = 0,
                    Fin_Total_Inv = Convert.ToDecimal(txt7TotalInvestment)
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
                    Ref_Name1 = txt8Name1.Text,
                    Ref_Relat1 = txt8Relation1.Text,
                    Ref_Addr1 = txt8Address1.Text,
                    Ref_Pin1 = Convert.ToInt32(txt8Pin1),
                    Ref_City1 = txt8City1.Text,
                    Ref_State1 = txt8State1.Text,
                    Ref_Country1 = txt8Country1.Text,
                    Ref_Mob_Tel1 = Convert.ToInt64(txt8Mobile1),
                    Ref_Email1 = txt8Email1.Text,
                    Ref_Name2 = txt8Name2.Text,
                    Ref_Relat2 = txt8Relation2.Text,
                    Ref_Addr2 = txt8Address2.Text,
                    Ref_Pin2 = Convert.ToInt32(txt8Pin2),
                    Ref_City2 = txt8City2.Text,
                    Ref_State2 = txt8State2.Text,
                    Ref_Country2 = txt8Country2.Text,
                    Ref_Mob_Tel2 = Convert.ToInt64(txt8Mobile2),
                    Ref_Email2 = txt8Email2.Text
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
                    Dec_Place = txt9Place.Text,
                    Dec_Date = Convert.ToDateTime(txt9DateOfDeclaration),
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

        public void EduAppDoc_Put_Id()
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
                    Doc1_Name = ddl9Identity.SelectedValue,
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
            double p = Convert.ToDouble(txt5LoanRequired.Text);
            int t = Convert.ToInt32(txt4E.Text);
            double ra = Convert.ToDouble(PerRate);
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