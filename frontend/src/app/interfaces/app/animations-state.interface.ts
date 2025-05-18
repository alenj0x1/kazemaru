export type AnimationProperty = 'projectThumbHeader'

export interface IAnimationStateValue {
    displayName: string;
    description: string;
    state: boolean;
}

export interface IAnimationsState {
    projectThumbHeader: IAnimationStateValue;
    projectThumbHoverIncrease: IAnimationStateValue;
    projectBlur: IAnimationStateValue
}