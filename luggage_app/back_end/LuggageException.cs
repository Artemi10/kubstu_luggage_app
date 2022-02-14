using System;

namespace luggage_app.back_end
{
    class LuggageException : SystemException
    {
        public LuggageException(string message): base(message) { }
    }
}