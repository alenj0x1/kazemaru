import IProjectStatus from './IProjectStatus';
import ITag from './ITag';

export default interface IProject {
  projectid: string;
  name: string;
  description: string;
  status: IProjectStatus;
  tags: ITag[];
  createdat: string;
  updatedat: string;
}
