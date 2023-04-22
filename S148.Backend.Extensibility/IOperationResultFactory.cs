// namespace S148.Backend.Extensibility;
//
// public interface IOperationResultFactory
// {
//     OperationResult FromStatusCode(string processResultCodeName);
//
//     OperationResult FromStatusCode<TProcessResultData>(string processResultCodeName,
//         TProcessResultData processResultData);
//     
//     OperationResult<TOperationResultData> FromStatusCode<TOperationResultData>(string processResultCodeName);
//     
//     OperationResult<TOperationResultData> FromStatusCode<TOperationResultData, TProcessResultData>(
//         string processResultCodeName, TProcessResultData processResultData);
// }