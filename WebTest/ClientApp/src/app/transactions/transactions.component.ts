import { Component, OnInit } from '@angular/core';
import { ApiCallServiceService } from '../_services/api-call-service.service';
import { Transaction } from '../_models/transaction';
import { Student } from '../_models/student';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css']
})
export class TransactionsComponent implements OnInit {
  transactions: Transaction[];
  students: Student[];
  newTransaction: Transaction = new Transaction();

  constructor(private apiService: ApiCallServiceService) { }

  ngOnInit() {
    this.apiService.getList<Transaction>("Transactions/List").subscribe(t => this.transactions = t);
    this.apiService.getList<Student>("Transactions/Students").subscribe(t => this.students = t);
  }

  AddTransaction() {
    this.newTransaction.studentId = Number(this.newTransaction.studentId);
    this.apiService.AddDB<Transaction>("Transactions", this.newTransaction).subscribe(t => {
      this.transactions.push(t);
      this.newTransaction = new Transaction();
    });
  }

}
