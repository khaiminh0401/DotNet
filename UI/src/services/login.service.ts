import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Account } from '../models/account';
import { catchError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  url = 'https://localhost:7103/api';
  constructor(private http: HttpClient) {}
  login(body: Account) {
    return this.http
      .post(this.url + '/login', body);
  }
}
