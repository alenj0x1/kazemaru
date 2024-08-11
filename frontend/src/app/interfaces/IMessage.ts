export enum MessageTypeEnum {
  Error = 'error',
  Success = 'success',
}

export interface IMessage {
  type: MessageTypeEnum;
  message: string;
}
