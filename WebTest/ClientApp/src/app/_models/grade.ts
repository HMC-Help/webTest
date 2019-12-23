import { Student } from './student';

export class Grade {
  public gradeId: number;
  public gradeName: string;
  public teacher: string;
  public gradePointTotal: number;
  public students: Student[];
}
