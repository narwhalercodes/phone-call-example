namespace Models;

using System;

public class PhoneCall : IDisposable
{
    // A delegate is essentially a type definition consisting of a function.
    // It can be declared inside or outside a class.
    // 
    // Declaring it inside a class prevents name collisions if you already
    // declared a delegate with the same name in current namespace.
    
    public delegate void SpeechTTSent(string s);
    public delegate void SpeechTTRecieved(string s);
    
    
    // State consisting of callbacks and an in-progress boolean.
    // - Callbacks are for the conversation in speech-to-text form.
    // - In-progress boolean indicates if the call hasnt been ended.
    // 
    // If you ask me - a callback is just a more implementation specific
    // type of listener, theres no event loop going on here. Just a callback.
    // 
    // Yes. I am aware you can do similar things like adding delegates to
    // events but thats not what we are trying to demonstrate. We just want a
    // single listener, whereas events lets you use multiple (and are more
    // of a thing very specific to each language how they work, not always
    // so useful, callbacks are superior hush hush).
    
    private SpeechTTSent? _callerListener = null;
    private SpeechTTRecieved? _contactListener = null;
    private bool _callInProgress = true;
    
    
    // setting up object
    
    public PhoneCall ListenOnCaller(SpeechTTSent? callerListener)
    {
        if (callerListener != null && !_callInProgress)
        {
            throw new ObjectDisposedException("");
        }
        _callerListener = callerListener;
        return this;
    }
    
    public PhoneCall ListenOnContact(SpeechTTRecieved? contactListener)
    {
        if (contactListener != null && !_callInProgress)
        {
            throw new ObjectDisposedException("");
        }
        _contactListener = contactListener;
        return this;
    }
    
    
    // speech
    
    public PhoneCall Speak(string speechInText)
    {
        if (!_callInProgress)
        {
            throw new ObjectDisposedException("");
        }
        _callerListener?.Invoke(speechInText);
        return this;
    }
    
    public PhoneCall Respond(string speechInText)
    {
        if (!_callInProgress)
        {
            throw new ObjectDisposedException("");
        }
        _contactListener?.Invoke(speechInText);
        return this;
    }
    
    
    // end call, etc.
    
    public PhoneCall HangUp(bool fromCallingSide = true)
    {
        if (fromCallingSide)
        {
            Speak("Beeep- Beeep.");
        }
        else
        {
            Respond("Beeep- Beeep.");
        }
        _callInProgress = false;
        return this;
    }
    
    public PhoneCall UnregisterListeners()
    {
        _callerListener = null;
        _contactListener = null;
        return this;
    }
    
    void IDisposable.Dispose()
    {
        UnregisterListeners();
        _callInProgress = false;
    }
}
