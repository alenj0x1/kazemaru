import ITag from "./ITag";

export default interface IProject {
  projectId: string;
  name: string;
  description: string;
  status: number;
  tags: ITag[];
  createdAt: string;
  updatedAt: string;
}