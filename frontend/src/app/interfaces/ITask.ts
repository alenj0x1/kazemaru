import ITaskStatus from './ITaskStatus';

export default interface ITask {
  taskid: string;
  projectid: string;
  name: string;
  description: string | null;
  status: ITaskStatus;
  createdat: string;
  updatedat: string;
}
