
namespace 스쿼드_도서관
{
    partial class UserJoin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userMan = new System.Windows.Forms.RadioButton();
            this.checkButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.userWoman = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.userBirth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.userPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.userEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.userDomain = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.userID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.userPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.userPasswordCheck = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.userRoadAddress = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.userDetailAddress = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(99, 79);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(166, 21);
            this.userName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(136, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "회 원 가 입";
            // 
            // userMan
            // 
            this.userMan.AutoSize = true;
            this.userMan.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.userMan.Location = new System.Drawing.Point(290, 81);
            this.userMan.Name = "userMan";
            this.userMan.Size = new System.Drawing.Size(51, 17);
            this.userMan.TabIndex = 2;
            this.userMan.TabStop = true;
            this.userMan.Text = "남자";
            this.userMan.UseVisualStyleBackColor = true;
            // 
            // checkButton
            // 
            this.checkButton.BackColor = System.Drawing.Color.Gainsboro;
            this.checkButton.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkButton.Location = new System.Drawing.Point(332, 251);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(75, 30);
            this.checkButton.TabIndex = 3;
            this.checkButton.Text = "중복확인";
            this.checkButton.UseVisualStyleBackColor = false;
            this.checkButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(43, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "이름";
            // 
            // userWoman
            // 
            this.userWoman.AutoSize = true;
            this.userWoman.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.userWoman.Location = new System.Drawing.Point(347, 81);
            this.userWoman.Name = "userWoman";
            this.userWoman.Size = new System.Drawing.Size(51, 17);
            this.userWoman.TabIndex = 5;
            this.userWoman.TabStop = true;
            this.userWoman.Text = "여자";
            this.userWoman.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(31, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "생년월일";
            // 
            // userBirth
            // 
            this.userBirth.Location = new System.Drawing.Point(99, 106);
            this.userBirth.Name = "userBirth";
            this.userBirth.Size = new System.Drawing.Size(166, 21);
            this.userBirth.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(96, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "예시) 2021년 9월 30일 -> 210930";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(31, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "전화번호";
            // 
            // userPhone
            // 
            this.userPhone.Location = new System.Drawing.Point(99, 162);
            this.userPhone.Name = "userPhone";
            this.userPhone.Size = new System.Drawing.Size(227, 21);
            this.userPhone.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(37, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "이메일";
            // 
            // userEmail
            // 
            this.userEmail.Location = new System.Drawing.Point(99, 218);
            this.userEmail.Name = "userEmail";
            this.userEmail.Size = new System.Drawing.Size(155, 21);
            this.userEmail.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(256, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "@";
            // 
            // userDomain
            // 
            this.userDomain.FormattingEnabled = true;
            this.userDomain.Items.AddRange(new object[] {
            "naver.com",
            "gmail.com",
            "hanmail.net",
            "daum.net"});
            this.userDomain.Location = new System.Drawing.Point(276, 218);
            this.userDomain.Name = "userDomain";
            this.userDomain.Size = new System.Drawing.Size(102, 20);
            this.userDomain.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(44, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "아이디";
            // 
            // userID
            // 
            this.userID.Location = new System.Drawing.Point(99, 256);
            this.userID.Name = "userID";
            this.userID.Size = new System.Drawing.Size(227, 21);
            this.userID.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(97, 290);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(265, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "* 영어, 숫자 포함 가능 5자리 이상,  15자리 미만";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(34, 315);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "비밀번호";
            // 
            // userPassword
            // 
            this.userPassword.Location = new System.Drawing.Point(99, 313);
            this.userPassword.Name = "userPassword";
            this.userPassword.PasswordChar = '*';
            this.userPassword.Size = new System.Drawing.Size(227, 21);
            this.userPassword.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(8, 347);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "비밀번호 확인";
            // 
            // textBox7
            // 
            this.userPasswordCheck.Location = new System.Drawing.Point(99, 344);
            this.userPasswordCheck.Name = "textBox7";
            this.userPasswordCheck.PasswordChar = '*';
            this.userPasswordCheck.Size = new System.Drawing.Size(227, 21);
            this.userPasswordCheck.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(21, 390);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "도로명 주소";
            // 
            // userRoadAddress
            // 
            this.userRoadAddress.Location = new System.Drawing.Point(98, 388);
            this.userRoadAddress.Multiline = true;
            this.userRoadAddress.Name = "userRoadAddress";
            this.userRoadAddress.Size = new System.Drawing.Size(227, 72);
            this.userRoadAddress.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(29, 475);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "상세 주소";
            // 
            // userDetailAddress
            // 
            this.userDetailAddress.Location = new System.Drawing.Point(99, 469);
            this.userDetailAddress.Name = "userDetailAddress";
            this.userDetailAddress.Size = new System.Drawing.Size(227, 21);
            this.userDetailAddress.TabIndex = 25;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(332, 340);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 27;
            this.button2.Text = "확인";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(174, 505);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 35);
            this.button3.TabIndex = 28;
            this.button3.Text = "확인";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.Location = new System.Drawing.Point(96, 188);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(204, 12);
            this.label15.TabIndex = 30;
            this.label15.Text = "예시) 010-1111-2222 -> 01011112222";
            // 
            // UserJoin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(424, 561);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.userDetailAddress);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.userRoadAddress);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.userPasswordCheck);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.userPassword);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.userID);
            this.Controls.Add(this.userDomain);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.userEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.userPhone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userBirth);
            this.Controls.Add(this.userWoman);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.userMan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userName);
            this.Name = "UserJoin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User_login1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton userMan;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton userWoman;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userBirth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox userPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox userEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox userDomain;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox userPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox userPasswordCheck;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox userRoadAddress;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox userDetailAddress;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox userID;
    }
}