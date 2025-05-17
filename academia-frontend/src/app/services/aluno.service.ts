import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Aluno {
  id: number;
  nome: string;
  email: string;
}

@Injectable({
  providedIn: 'root'
})
export class AlunoService {
  private apiUrl = 'https://localhost:5001/api/Aluno';

  constructor(private http: HttpClient) {}

  getAlunos(): Observable<Aluno[]> {
    return this.http.get<Aluno[]>(this.apiUrl);
  }

  getAluno(id: number): Observable<Aluno> {
    return this.http.get<Aluno>(`${this.apiUrl}/${id}`);
  }

  createAluno(aluno: Aluno): Observable<Aluno> {
    return this.http.post<Aluno>(this.apiUrl, aluno);
  }

  updateAluno(id: number, aluno: Aluno): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, aluno);
  }

  deleteAluno(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
