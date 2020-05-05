using System;

namespace BusinessService.Api.Data
{
    public static class EitherModel
    {
        public static Left<TLeft, TRight> Left<TLeft, TRight>(TLeft value) => new Left<TLeft, TRight>(value);
        public static Right<TLeft, TRight> Right<TLeft, TRight>(TRight value) => new Right<TLeft, TRight>(value);
        
        public static Either<string, TRight2> Map<TRight1, TRight2>(this Either<string,TRight1> value, Func<TRight1, TRight2> funcRight) =>
            value  switch
            { 
                Left<string, TRight1> val => Left<string,TRight2>(val.Value),
                Right<string, TRight1> val => Right<string,TRight2>(funcRight(val.Value)),
                _ => Left<string,TRight2>("Some thing went wrong")
            }; 
        public static Either<string, TRight2> MapEither<TRight1, TRight2>(this Either<string,TRight1> value, Func<TRight1, Either<string,TRight2>> funcRight) =>
            value  switch
            { 
                Left<string, TRight1> val => Left<string,TRight2>(val.Value),
                Right<string, TRight1> val => funcRight(val.Value),
                _ => Left<string,TRight2>("Some thing went wrong")
            }; 
    }
}