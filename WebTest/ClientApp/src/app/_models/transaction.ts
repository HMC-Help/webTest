import { Student } from './student';

export class Transaction {
  public transactionId: number;
  public studentId: number;
  public transactionDate: Date;
  public transactionType: string;
  public points: number;
  public transactionDescription: string;
  public student: Student;
}
