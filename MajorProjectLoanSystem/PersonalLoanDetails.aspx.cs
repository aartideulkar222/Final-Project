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
    public partial class PersonalLoanDetails : System.Web.UI.Page
    {
        string PerRate;
        double emi, lastEmi, interestAmt;

        protected void Page_Load(object sender, EventArgs e)
        {
            string tps = Convert.ToString(Session["Personal_Rate"]);
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
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "successAlert()", true);
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
                    EmpEduHome_Put_Id();
                    PropPersonal_Put_Id();
                    PurpPersonal_Put_Id();
                    Financial_Put_Id();
                    Reference_Put_Id();
                    Declar_Put_Id();
                    PersonalAppDoc_Put_Id();

                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "successAlert()", true);
                }
                else
                {
                    //POST method calling
                    Personal_Post();
                    Gstin_Post();
                    EmpEduHome_Post();
                    PropPersonal_Post();
                    PurpPersonal_Post();
                    Financial_Post();
                    Reference_Post();
                    Declar_Post();
                    PersonalAppDoc_Post();

                    Emi_Calculation_Method();

                    lblApp_ID.Text = GenerateID();
                    LoanAppliedDetailsPersonal_Post();
                    StatusPersonal_Post();

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

        public void PropPersonal_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("PropPersonal/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PropPersonalClass>();
                    readTask.Wait();

                    var proppersonal = readTask.Result;

                    txt4Amount.Text = Convert.ToString(proppersonal.Ppr_Amount);
                    txt4Tenure.Text = Convert.ToString(proppersonal.Ppr_Terms);
                    ddl4RepaymentMode.SelectedValue = proppersonal.Ppr_Repayt_Mode;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void PurpPersonal_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("PurpPersonal/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PurpPersonalClass>();
                    readTask.Wait();

                    var purppersonal = readTask.Result;

                    var ppu_reason = purppersonal.Ppu_Reason.Split('_');

                    ddl6LoanPurpose.SelectedValue = ppu_reason[0];
                    txt6LoanPurposeOther.Text = ppu_reason[1];
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

                    ddl5EmploymentType.SelectedValue = financial.Fin_Status;
                    txt5GrossIncome.Text = Convert.ToString(financial.Fin_Inc_Gross);
                    txt5NetIncome.Text = Convert.ToString(financial.Fin_Inc_Net);
                    txt5OtherIncome.Text = Convert.ToString(financial.Fin_Inc_Othr);
                    txt5TotalIncome.Text = Convert.ToString(financial.Fin_Inc_Total);
                    txt5Bank1.Text = financial.Fin_Bank1_Name;
                    txt5Branch1.Text = financial.Fin_Bank1_Branch;
                    txt5AccountType1.Text = financial.Fin_Bank1_Ac_Type;
                    txt5AccountNo1.Text = financial.Fin_Bank1_Ac_No;
                    txt5Bank2.Text = financial.Fin_Bank2_Name;
                    txt5Branch2.Text = financial.Fin_Bank2_Branch;
                    txt5AccountType2.Text = financial.Fin_Bank2_Ac_Type;
                    txt5AccountNo2.Text = financial.Fin_Bank2_Ac_No;
                    txt5TotalInvestment.Text = Convert.ToString(financial.Fin_Total_Inv);
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

        public void PersonalAppDoc_Get_Id()
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

                    if(personalappdoc.Doc1 != null)
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

        public void EmpEduHome_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in EmpEduHome table
                var empeduhome = new EmpEduHomeClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Org_Res_Own = null,
                    Org_Employment_Nat = ddl6EmploymentType.SelectedValue,
                    Org_Nat = ddl6OrganisationType.SelectedValue + txt6OrganisationTypeOther.Text,
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

        public void PropPersonal_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in PropPersonal table
                var proppersonal = new PropPersonalClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Ppr_Amount = Convert.ToDecimal(txt4Amount.Text),
                    Ppr_Terms = Convert.ToInt32(txt4Tenure.Text),
                    Ppr_Proces_Fee = 0,
                    Ppr_Roi = 0,
                    Ppr_Repayt_Mode = ddl4RepaymentMode.SelectedValue
                };

                var postTask = client.PostAsJsonAsync<PropPersonalClass>("PropPersonal", proppersonal);
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

        public void PurpPersonal_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in PurpPersonal table
                var purppersonal = new PurpPersonalClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Ppu_Reason = ddl6LoanPurpose.SelectedValue + "_" + txt6LoanPurposeOther.Text
                };

                var postTask = client.PostAsJsonAsync<PurpPersonalClass>("PurpPersonal", purppersonal);
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
                    Fin_Status = ddl5EmploymentType.SelectedValue,
                    Fin_Inc_Gross = Convert.ToDecimal(txt5GrossIncome.Text),
                    Fin_Inc_Net = Convert.ToDecimal(txt5NetIncome.Text),
                    Fin_Inc_Othr = Convert.ToDecimal(txt5OtherIncome.Text),
                    Fin_Inc_Total = Convert.ToDecimal(txt5TotalIncome.Text),
                    Fin_Bank1_Name = txt5Bank1.Text,
                    Fin_Bank1_Branch = txt5Branch1.Text,
                    Fin_Bank1_Ac_Type = txt5AccountType1.Text,
                    Fin_Bank1_Ac_No = txt5AccountNo1.Text,
                    Fin_Bank2_Name = txt5Bank2.Text,
                    Fin_Bank2_Branch = txt5Branch2.Text,
                    Fin_Bank2_Ac_Type = txt5AccountType2.Text,
                    Fin_Bank2_Ac_No = txt5AccountNo2.Text,
                    Fin_Deposits_Inv = 0,
                    Fin_Shares_Inv = 0,
                    Fin_Insurance_Inv = 0,
                    Fin_Mutual_Funds_Inv = 0,
                    Fin_Others_Inv = 0,
                    Fin_Total_Inv = Convert.ToDecimal(txt5TotalInvestment.Text)
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
                    Ref_Name1 = txt7Name1.Text,
                    Ref_Relat1 = txt7Relation1.Text,
                    Ref_Addr1 = txt7Address1.Text,
                    Ref_Pin1 = Convert.ToInt32(txt7Pin1.Text),
                    Ref_City1 = txt7City1.Text,
                    Ref_State1 = txt7State1.Text,
                    Ref_Country1 = txt7Country1.Text,
                    Ref_Mob_Tel1 = Convert.ToInt64(txt7Mobile1.Text),
                    Ref_Email1 = txt7Email1.Text,
                    Ref_Name2 = txt7Name2.Text,
                    Ref_Relat2 = txt7Relation2.Text,
                    Ref_Addr2 = txt7Address2.Text,
                    Ref_Pin2 = Convert.ToInt32(txt7Pin2.Text),
                    Ref_City2 = txt7City2.Text,
                    Ref_State2 = txt7State2.Text,
                    Ref_Country2 = txt7Country2.Text,
                    Ref_Mob_Tel2 = Convert.ToInt64(txt7Mobile2.Text),
                    Ref_Email2 = txt7Email2.Text
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

        public void PersonalAppDoc_Post()
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

                //HTTP POST in PersonalAppDoc table
                var personalappdoc = new PersonalAppDocClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Doc1_Name = ddl8Identity.SelectedValue,
                    Doc1 = bytes1,
                    Doc1_Status = "Pending"
                };

                var postTask = client.PostAsJsonAsync<PersonalAppDocClass>("PersonalAppDoc", personalappdoc);
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

        public void LoanAppliedDetailsPersonal_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in LoanAppliedDetails table
                var ladp = new LoanAppliedDetailsPersonalClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Per_ID = lblApp_ID.Text,
                    Per_Amount = Convert.ToDecimal(txt4Amount.Text),
                    Per_Rate = Convert.ToDecimal(PerRate),
                    Per_Tenure = Convert.ToInt32(txt4Tenure.Text),
                    Per_Emi = Convert.ToDecimal(emi),
                    Per_Last_Emi = Convert.ToDecimal(lastEmi),
                    Per_Interest = Convert.ToDecimal(interestAmt)
                };

                var postTask = client.PostAsJsonAsync<LoanAppliedDetailsPersonalClass>("LoanAppliedDetailsPersonal", ladp);
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

        public void StatusPersonal_Post()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP POST in Status table
                var sp = new StatusPersonalClass()
                {
                    P_ID = Convert.ToInt32(Session["USER_ID"]),
                    Personal_Applied = "Yes",
                    Personal_Status = "Pending",
                    Personal_Correction = "NA"
                };

                var postTask = client.PostAsJsonAsync<StatusPersonalClass>("StatusPersonal", sp);
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

        public void PropPersonal_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP PUT in PropPersonal table
                var proppersonal = new PropPersonalClass()
                {
                    Ppr_Amount = Convert.ToDecimal(txt4Amount),
                    Ppr_Terms = Convert.ToInt32(txt4Tenure),
                    Ppr_Proces_Fee = 0,
                    Ppr_Roi = 0,
                    Ppr_Repayt_Mode = ddl4RepaymentMode.SelectedValue
                };

                var putTask = client.PutAsJsonAsync<PropPersonalClass>("PropPersonal/" + Convert.ToInt32(Session["USER_ID"]), proppersonal);
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

        public void PurpPersonal_Put_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //HTTP PUT in PurpPersonal table
                var purppersonal = new PurpPersonalClass()
                {
                    Ppu_Reason = ddl6LoanPurpose.SelectedValue + "_" + txt6LoanPurposeOther.Text
                };

                var putTask = client.PutAsJsonAsync<PurpPersonalClass>("PurpPersonal/" + Convert.ToInt32(Session["USER_ID"]), purppersonal);
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
                    Fin_Status = ddl5EmploymentType.SelectedValue,
                    Fin_Inc_Gross = Convert.ToDecimal(txt5GrossIncome),
                    Fin_Inc_Net = Convert.ToDecimal(txt5NetIncome),
                    Fin_Inc_Othr = Convert.ToDecimal(txt5OtherIncome),
                    Fin_Inc_Total = Convert.ToDecimal(txt5TotalIncome),
                    Fin_Bank1_Name = txt5Bank1.Text,
                    Fin_Bank1_Branch = txt5Branch1.Text,
                    Fin_Bank1_Ac_Type = txt5AccountType1.Text,
                    Fin_Bank1_Ac_No = txt5AccountNo1.Text,
                    Fin_Bank2_Name = txt5Bank2.Text,
                    Fin_Bank2_Branch = txt5Branch2.Text,
                    Fin_Bank2_Ac_Type = txt5AccountType2.Text,
                    Fin_Bank2_Ac_No = txt5AccountNo2.Text,
                    Fin_Deposits_Inv = 0,
                    Fin_Shares_Inv = 0,
                    Fin_Insurance_Inv = 0,
                    Fin_Mutual_Funds_Inv = 0,
                    Fin_Others_Inv = 0,
                    Fin_Total_Inv = Convert.ToDecimal(txt5TotalInvestment)
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

        public void PersonalAppDoc_Put_Id()
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
            double p = Convert.ToDouble(txt4Amount.Text);
            int t = Convert.ToInt32(txt4Tenure.Text);
            t = t * 12;
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