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
    public partial class GoldLoanDetails : System.Web.UI.Page
    {
        string PerRate;
        double emi, lastEmi, interestAmt;

        protected void Page_Load(object sender, EventArgs e)
        {
            string tps = Convert.ToString(Session["Gold_Rate"]);
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
                    EmpGold_Put_Id();
                    PropGold_Put_Id();
                    PurpGold_Put_Id();
                    Nominee_Put_Id();
                    Declar_Put_Id();
                    GoldAppDoc_Put_Id();
                }
                else
                {
                    //POST method calling
                    Personal_Post();
                    Gstin_Post();
                    EmpGold_Post();
                    PropGold_Post();
                    PurpGold_Post();
                    Nominee_Post();
                    Declar_Post();
                    GoldAppDoc_Post();

                    Emi_Calculation_Method();

                    lblApp_ID.Text = GenerateID();
                    LoanAppliedDetailsGold_Post();
                    StatusGold_Post();

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

                    ddl3UnderGst.SelectedValue = gstin.Gst_Reg;
                    ddl3GstExemption.SelectedValue = gstin.Gst_Exem;
                    txt3ExemptionReason.Text = gstin.Gst_Exem_Reason;
                    ddl3GstType.SelectedValue = gstin.Gst_Reg_Type;
                    ddl3EconimicZone.Text = gstin.Gst_Eco_Zone;
                    txt3GstinDefault.Text = gstin.Gst_default;
                    txt3Address.Text = gstin.Gstin_Addr;
                    txt3Pin.Text = Convert.ToString(gstin.Gst_Pin);
                    txt3City.Text = gstin.Gst_City;
                    txt3State.Text = gstin.Gst_State;
                    txt3Country.Text = gstin.Gst_Country;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void EmpGold_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("EmpGold/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EmpGoldClass>();
                    readTask.Wait();

                    var empgold = readTask.Result;

                    var org_nat = empgold.Ge_Org_Type.Split('_');

                    ddl2OccupationType.SelectedValue = empgold.Ge_Occ_Type;
                    ddl2OrganisationNature.SelectedValue = org_nat[0];
                    txt2OrganisationNatureOther.Text = org_nat[1];
                    txt2EmployerName.Text = empgold.Ge_Emp_Buss_Name;
                    txt2Designation.Text = empgold.Ge_Designation;
                    txt2EmploymentYears.Text = Convert.ToString(empgold.Ge_Curr_Work_Years);
                    txt2WorkExperience.Text = Convert.ToString(empgold.Ge_Total_work_Years);
                    txt2NetAnnualIncome.Text = Convert.ToString(empgold.Ge_Net_Ann_Inc);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void PropGold_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("PropGold/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PropGoldClass>();
                    readTask.Wait();

                    var propgold = readTask.Result;

                    txt4LoanAmount.Text = Convert.ToString(propgold.Gpr_Loan_Amount);
                    txt4Tenure.Text = Convert.ToString(propgold.Gpr_Tenure_Months);
                    txt4PaymentDate.Text = Convert.ToString(propgold.Gpr_Payment_Date);
                    ddl4InterestPaymentMode.SelectedValue = propgold.Gpr_Int_Pay_Mode;
                    ddl4DisbursalMode.SelectedValue = propgold.Gpr_Disburs_Mode;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void PurpGold_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("PurpGold/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PurpGoldClass>();
                    readTask.Wait();

                    var purpgold = readTask.Result;

                    var ppu_reason = purpgold.Gpu_Purpose.Split('_');

                    ddl5LoanPurpose.SelectedValue = ppu_reason[0];
                    txt5LoanPurposeOther.Text = ppu_reason[1];
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void Nominee_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("Nominee/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<NomineeClass>();
                    readTask.Wait();

                    var nominee = readTask.Result;

                    var nomname = nominee.Nom_Name.Split('_');

                    txt6ApplicantName.Text = nominee.Nom_App_Name;
                    txt6ApplicantAddress.Text = nominee.Nom_App_Addr;
                    txt6NomineeFirst.Text = nomname[0];
                    txt6NomineeMiddle.Text = nomname[0];
                    txt6NomineeLast.Text = nomname[0];
                    txt6NomineeAddress.Text = nominee.Nom_Addr;
                    txt6Relationship.Text = nominee.Nom_Relation;
                    txt6NomineeAge.Text = Convert.ToString(nominee.Nom_Age);
                    txt6NomineeDOB.Text = Convert.ToString(nominee.Nom_Dob);
                    txt6GuardianName.Text = nominee.Nom_Guar_Name;
                    txt6GuardianAge.Text = Convert.ToString(nominee.Nom_Guar_Age);
                    txt6GuardianAddress.Text = nominee.Nom_Guar_Addr;

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
                    output_image.ImageUrl = "data:Image/jpeg;base64," + str1Base64;
                    output_sign.ImageUrl = "data:Image/jpeg;base64," + str2Base64;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void GoldAppDoc_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("PersonalAppDoc/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PersonalAppDocClass>();
                    readTask.Wait();

                    var personalappdoc = readTask.Result;

                    if (personalappdoc.Doc1 != null)
                    {

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
                    Gst_Reg = ddl3UnderGst.SelectedValue,
                    Gst_Exem = ddl3GstExemption.SelectedValue,
                    Gst_Exem_Reason = txt3ExemptionReason.Text,
                    Gst_Reg_Type = ddl3GstType.SelectedValue,
                    Gst_Eco_Zone = ddl3EconimicZone.Text,
                    Gst_default = txt3GstinDefault.Text,
                    Gstin_Addr = txt3Address.Text,
                    Gst_Pin = Convert.ToInt32(txt3Pin.Text),
                    Gst_City = txt3City.Text,
                    Gst_State = txt3State.Text,
                    Gst_Country = txt3Country.Text
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

        public void EmpGold_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in EmpGold table
                var empgold = new EmpGoldClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Ge_Occ_Type = ddl2OccupationType.SelectedValue,
                    Ge_Org_Type = ddl2OrganisationNature.SelectedValue + "_" + txt2OrganisationNatureOther.Text,
                    Ge_Emp_Buss_Name = txt2EmployerName.Text,
                    Ge_Designation = txt2Designation.Text,
                    Ge_Curr_Work_Years = Convert.ToInt32(txt2EmploymentYears.Text),
                    Ge_Total_work_Years = Convert.ToInt32(txt2WorkExperience.Text),
                    Ge_Net_Ann_Inc = Convert.ToInt32(txt2NetAnnualIncome.Text)
                };

                var postTask = client.PostAsJsonAsync<EmpGoldClass>("EmpGold", empgold);
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

        public void PropGold_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in PropGold table
                var propgold = new PropGoldClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Gpr_Loan_Amount = Convert.ToDecimal(txt4LoanAmount.Text),
                    Gpr_Tenure_Months = Convert.ToInt32(txt4Tenure.Text),
                    Gpr_Payment_Date = Convert.ToDateTime(txt4PaymentDate.Text),
                    Gpr_Int_Pay_Mode = ddl4InterestPaymentMode.SelectedValue,
                    Gpr_Disburs_Mode = ddl4DisbursalMode.SelectedValue
                };

                var postTask = client.PostAsJsonAsync<PropGoldClass>("PropGold", propgold);
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

        public void PurpGold_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in PurpGold table
                var purpgold = new PurpGoldClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Gpu_Purpose = ddl5LoanPurpose.SelectedValue + "_" + txt5LoanPurposeOther.Text
                };

                var postTask = client.PostAsJsonAsync<PurpGoldClass>("PurpGold", purpgold);
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

        public void Nominee_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in Nominee table
                var nominee = new NomineeClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Nom_App_Name = txt6ApplicantName.Text,
                    Nom_App_Addr = txt6ApplicantAddress.Text,
                    Nom_Name = txt6NomineeFirst.Text + "_" + txt6NomineeMiddle.Text + "_" + txt6NomineeLast.Text,
                    Nom_Addr = txt6NomineeAddress.Text,
                    Nom_Relation = txt6Relationship.Text,
                    Nom_Age = Convert.ToInt32(txt6NomineeAge.Text),
                    Nom_Dob = Convert.ToDateTime(txt6NomineeDOB.Text),
                    Nom_Guar_Name = txt6GuardianName.Text,
                    Nom_Guar_Age = Convert.ToInt32(txt6GuardianAge.Text),
                    Nom_Guar_Addr = txt6GuardianAddress.Text
                };

                var postTask = client.PostAsJsonAsync<NomineeClass>("Nominee", nominee);
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

        public void GoldAppDoc_Post()
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

                //HTTP POST in GoldAppDoc table
                var goldappdoc = new GoldAppDocClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Doc1_Name = ddl7Identity.SelectedValue,
                    Doc1 = bytes1,
                    Doc1_Status = "Pending",
                    Doc2_Name = ddl7Residence.SelectedValue,
                    Doc2 = bytes2,
                    Doc2_Status = "Pending",
                    Doc3_Name = ddl7Financial.SelectedValue,
                    Doc3 = bytes3,
                    Doc3_Status = "Pending"
                };

                var postTask = client.PostAsJsonAsync<GoldAppDocClass>("GoldAppDoc", goldappdoc);
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

        public void LoanAppliedDetailsGold_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in LoanAppliedDetails table
                var ladp = new LoanAppliedDetailsGoldClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Gold_ID = lblApp_ID.Text,
                    Gold_Amount = Convert.ToDecimal(txt4LoanAmount.Text),
                    Gold_Rate = Convert.ToDecimal(PerRate),
                    Gold_Tenure = Convert.ToInt32(txt4Tenure.Text),
                    Gold_Emi = Convert.ToDecimal(emi),
                    Gold_Last_Emi = Convert.ToDecimal(lastEmi),
                    Gold_Interest = Convert.ToDecimal(interestAmt)
                };

                var postTask = client.PostAsJsonAsync<LoanAppliedDetailsGoldClass>("LoanAppliedDetailsGold", ladp);
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

        public void StatusGold_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in Status table
                var sp = new StatusGoldClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Gold_Applied = "Yes",
                    Gold_Status = "Pending",
                    Gold_Correction = "NA"
                };

                var postTask = client.PostAsJsonAsync<StatusGoldClass>("StatusGold", sp);
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
                    App_Name = txt1ApplicantFirst.Text + "_" + txt1ApplicantMiddle.Text + "_" + txt1ApplicantLast.Text,
                    App_Fath_Spou_Name = txt1FatherFirst.Text + "_" + txt1FatherMiddle.Text + "_" + txt1FatherLast.Text,
                    App_Mother_Name = txt1MotherFirst.Text + "_" + txt1MotherMiddle.Text + "_" + txt1MotherLast.Text,
                    App_Status = ddl1Status.SelectedValue,
                    App_Pan = txt1PAN.Text,
                    App_Doc_Type = ddl1Document.SelectedValue,
                    App_Doc_No = txt1Document.Text,
                    App_Doc_Exp = Convert.ToDateTime(txt1Expiry),
                    App_Ckyc_No = txt1CKYC.Text,
                    App_Dob = Convert.ToDateTime(txt1DOB),
                    App_Gender = ddl1Gender.SelectedValue,
                    App_Nationality = txt1Nationality.Text,
                    App_Religion = ddl1Community.SelectedValue + "_" + txt1Community.Text,
                    App_Category = ddl1Category.SelectedValue + "_" + txtCategory.Text,
                    App_Disability = ddl1Disability.SelectedValue,
                    App_Education = ddl1Education.SelectedValue + "_" + txt1Education.Text,
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
                    Gst_Reg = ddl3UnderGst.SelectedValue,
                    Gst_Exem = ddl3GstExemption.SelectedValue,
                    Gst_Exem_Reason = txt3ExemptionReason.Text,
                    Gst_Reg_Type = ddl3GstType.SelectedValue,
                    Gst_Eco_Zone = ddl3EconimicZone.Text,
                    Gst_default = txt3GstinDefault.Text,
                    Gstin_Addr = txt3Address.Text,
                    Gst_Pin = Convert.ToInt32(txt3Pin.Text),
                    Gst_City = txt3City.Text,
                    Gst_State = txt3State.Text,
                    Gst_Country = txt3Country.Text
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

        public void EmpGold_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP PUT in EmpGold table
                var empgold = new EmpGoldClass()
                {
                    Ge_Occ_Type = ddl2OccupationType.SelectedValue,
                    Ge_Org_Type = ddl2OrganisationNature.SelectedValue + "_" + txt2OrganisationNatureOther.Text,
                    Ge_Emp_Buss_Name = txt2EmployerName.Text,
                    Ge_Designation = txt2Designation.Text,
                    Ge_Curr_Work_Years = Convert.ToInt32(txt2EmploymentYears.Text),
                    Ge_Total_work_Years = Convert.ToInt32(txt2WorkExperience.Text),
                    Ge_Net_Ann_Inc = Convert.ToInt32(txt2NetAnnualIncome)
                };

                var putTask = client.PutAsJsonAsync<EmpGoldClass>("EmpGold/" + Convert.ToInt32(Session["USER_ID"]), empgold);
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

        public void PropGold_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP PUT in PropGold table
                var propgold = new PropGoldClass()
                {
                    Gpr_Loan_Amount = Convert.ToDecimal(txt4LoanAmount.Text),
                    Gpr_Tenure_Months = Convert.ToInt32(txt4Tenure.Text),
                    Gpr_Payment_Date = Convert.ToDateTime(txt4PaymentDate.Text),
                    Gpr_Int_Pay_Mode = ddl4InterestPaymentMode.SelectedValue,
                    Gpr_Disburs_Mode = ddl4DisbursalMode.SelectedValue
                };

                var putTask = client.PutAsJsonAsync<PropGoldClass>("PropGold/" + Convert.ToInt32(Session["USER_ID"]), propgold);
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

        public void PurpGold_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP PUT in PurpGold table
                var purpgold = new PurpGoldClass()
                {
                    Gpu_Purpose = ddl5LoanPurpose.SelectedValue + "_" + txt5LoanPurposeOther.Text
                };

                var putTask = client.PutAsJsonAsync<PurpGoldClass>("PurpGold/" + Convert.ToInt32(Session["USER_ID"]), purpgold);
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

        public void Nominee_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP PUT in Nominee table
                var nominee = new NomineeClass()
                {
                    Nom_App_Name = txt6ApplicantName.Text,
                    Nom_App_Addr = txt6ApplicantAddress.Text,
                    Nom_Name = txt6NomineeFirst.Text + "_" + txt6NomineeMiddle.Text + "_" + txt6NomineeLast.Text,
                    Nom_Addr = txt6NomineeAddress.Text,
                    Nom_Relation = txt6Relationship.Text,
                    Nom_Age = Convert.ToInt32(txt6NomineeAge.Text),
                    Nom_Dob = Convert.ToDateTime(txt6NomineeDOB.Text),
                    Nom_Guar_Name = txt6GuardianName.Text,
                    Nom_Guar_Age = Convert.ToInt32(txt6GuardianAge.Text),
                    Nom_Guar_Addr = txt6GuardianAddress.Text
                };

                var putTask = client.PutAsJsonAsync<NomineeClass>("Nominee/" + Convert.ToInt32(Session["USER_ID"]), nominee);
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

        public void GoldAppDoc_Put_Id()
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

                //HTTP PUT in GoldAppDoc table
                var goldappdoc = new GoldAppDocClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Doc1_Name = ddl7Identity.SelectedValue,
                    Doc1 = bytes1,
                    Doc1_Status = "Pending",
                    Doc2_Name = ddl7Residence.SelectedValue,
                    Doc2 = bytes2,
                    Doc2_Status = "Pending",
                    Doc3_Name = ddl7Financial.SelectedValue,
                    Doc3 = bytes3,
                    Doc3_Status = "Pending"
                };

                var putTask = client.PutAsJsonAsync<GoldAppDocClass>("GoldAppDoc/" + Convert.ToInt32(Session["USER_ID"]), goldappdoc);
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
            double p = Convert.ToDouble(txt4LoanAmount.Text);
            int t = Convert.ToInt32(txt4Tenure.Text);
            t = t * 12;
            double ra = Convert.ToDouble(PerRate);
            ra = ra / (12 * 100);

            emi = (p * ra * Math.Pow(1 + ra, t)) / ((Math.Pow(1 + ra, t)) - 1);

            double ori = emi;
            emi = Math.Floor(emi);

            var tAmt = t * emi;
            var totalAmt = t * ori;
            totalAmt = Math.Round(totalAmt, 2);
            var balance = totalAmt - tAmt;
            lastEmi = emi + balance;
            interestAmt = totalAmt - p;
        }
    }
}