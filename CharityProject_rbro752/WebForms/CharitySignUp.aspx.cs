﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using BusinessObjects;

namespace CharityProject_rbro752.WebForms
{
    public partial class CharitySignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if(passwordSignUp.Value == passwordConfirmSignUp.Value)
            {
                int outputCharity,outputUser;
                BLL objBLL = new BLL();
                Charities objCharity = new Charities();
                objCharity.CharityName = charityNameTxt.Value;
                objCharity.Email = emailSignUp.Value;
                objCharity.PhoneNo = charityContactNumber.Value;
                objCharity.OpenHours = openHours.Value;
                objCharity.Address = address.Value;
                objCharity.Password = passwordSignUp.Value;
                if(websiteURL.Value == null)
                {
                    websiteURL.Value = "";
                }
                objCharity.URL = websiteURL.Value;

                outputCharity = objBLL.CharitySignUpBLL(objCharity);

                Users objUser = new Users();
                objUser.Email = emailSignUp.Value;
                objUser.Password = passwordSignUp.Value;
                objUser.UserType = "Charity";

                outputUser = objBLL.AddUserBLL(objUser);

                if (outputCharity > 0 && outputUser > 0)
                {
                    objBLL.send(objCharity);
                    ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Succesfully Registered as Charity'); window.location.href = 'CharitySignUp.aspx';", true);
                }
                else if (outputCharity <= 0 || outputUser <= 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Registration Failed'); window.location.href = 'CharitySignUp.aspx';", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Passwords must match!'); window.location.href = 'CharitySignUp.aspx';", true);
            }
        }
    }
}