import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Application {
  id: number;
  companyName: string;
  role: string;
  stage: string;
  appliedDate: string;
  location?: string;
  notes?: string;
}

@Injectable({
  providedIn: 'root'
})
export class ApplicationsService {
  private apiUrl = 'http://localhost:5007/api/applications';

  constructor(private http: HttpClient) {}

  getApplications(): Observable<Application[]> {
    return this.http.get<Application[]>(this.apiUrl);
  }

  createApplication(application: Application) {
    return this.http.post(this.apiUrl, application);
  }

  // add update and delete methods as needed
}
