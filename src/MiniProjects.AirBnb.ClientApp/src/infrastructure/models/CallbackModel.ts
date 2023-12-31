/*
    Represents a wrapper for callback function
 */
export class CallbackModel<T1, T2> {
    public callBack!: (args: T1) => Promise<T2>;
}