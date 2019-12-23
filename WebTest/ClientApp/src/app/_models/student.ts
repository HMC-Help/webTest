import { Grade } from './grade';
import { Transaction } from './transaction';

export class Student {
  public studentId: number;
  public gradeId: number;
  public studentName: string;
  public yiddishName: string;
  public message: string;
  public totalPoints: number;
  public grade: Grade;
  public transactions: Transaction[];
}
