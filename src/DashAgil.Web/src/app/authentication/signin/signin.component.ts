import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/core/services/auth/auth.service';
@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})
export class SigninComponent implements OnInit {
  loginForm: FormGroup;
  submitted = false;
  error = '';
  hide = true;
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService
  ) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit() {
    this.submitted = true;
    this.error = '';
    if (this.loginForm.invalid) {
      this.error = 'Usuário ou senha inválidos';
      return;
    } else {
      this.authService
        .login(this.loginForm.controls.username.value, this.loginForm.controls.password.value)
        .subscribe((res) => {
          this.router.navigate(['/dashboard/overview']);
        },
          () => {
            this.error = 'Usuário ou senha inválidos';
            this.submitted = false;
          }
        );
    }
  }
}
