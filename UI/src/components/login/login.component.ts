import { LoginService } from './../../services/login.service';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  providers: [LoginService],
})
export class LoginComponent {
  title = 'Login Form';
  loginForm: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    private loginService: LoginService,
    private router: Router
  ) {
    let session = sessionStorage.getItem('user');
    if(session != null){
      this.router.navigate(['/']);
    }
    this.loginForm = this.formBuilder.group({
      username: ['DKM'],
      password: ['04012003'],
    });
  }

  onSubmit() {
    let result = this.loginService.login(this.loginForm.value);
    result.subscribe((value) => {
      if (value != null) {
        sessionStorage.setItem("user",JSON.stringify(value));
        this.router.navigate(['/']);
      }
    });
  }
}
