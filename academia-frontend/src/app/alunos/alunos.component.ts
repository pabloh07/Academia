import { Component, OnInit } from '@angular/core';
import { AlunoService, Aluno } from '../services/aluno.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-alunos',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css']
})
export class AlunosComponent implements OnInit {
  alunos: Aluno[] = [];
  novoAluno: Aluno = { id: 0, nome: '', email: '' };
  editandoAluno: Aluno | null = null;

  constructor(private alunoService: AlunoService) {}

  ngOnInit(): void {
    this.carregarAlunos();
  }

  carregarAlunos(): void {
    this.alunoService.getAlunos().subscribe(alunos => this.alunos = alunos);
  }

  adicionarAluno(): void {
    this.alunoService.createAluno(this.novoAluno).subscribe(() => {
      this.carregarAlunos();
      this.novoAluno = { id: 0, nome: '', email: '' };
    });
  }

  editar(aluno: Aluno): void {
    this.editandoAluno = { ...aluno };
  }

  atualizarAluno(): void {
    if (this.editandoAluno) {
      this.alunoService.updateAluno(this.editandoAluno.id, this.editandoAluno).subscribe(() => {
        this.carregarAlunos();
        this.editandoAluno = null;
      });
    }
  }

  deletarAluno(id: number): void {
    this.alunoService.deleteAluno(id).subscribe(() => this.carregarAlunos());
  }

  cancelarEdicao(): void {
    this.editandoAluno = null;
  }
}
