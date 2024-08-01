
  // This file allows you to configure ESLint according to your project's needs, so that you
  // can control the strictness of the linter, the plugins to use, and more.

  // For more information about configuring ESLint, visit https://eslint.org/docs/user-guide/configuring/

  import { Injectable } from '@angular/core';
  import { HttpClient } from '@angular/common/http';
  import { Observable } from 'rxjs';


  @Injectable({
    providedIn: 'root'
  })

  export class Services {
    constructor(private http: HttpClient) { }

    getEmployee(): Observable<any> {
      return this.http.get('https://localhost:44334/api/Employee');
    }
  }



