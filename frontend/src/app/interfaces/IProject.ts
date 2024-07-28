import IProjectStatus from './IProjectStatus';
import ITag from './ITag';

export default interface IProject {
  projectId: string;
  name: string;
  description: string;
  status: IProjectStatus;
  tags: ITag[];
  createdAt: string;
  updatedAt: string;
}
