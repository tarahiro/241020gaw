using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using gaw241020;
using System;

namespace gaw241020.Presenter
{
    public interface ICommand
    {
        void Execute();


        bool IsEndCommand { get; }

        bool IsEndState { get; }

        void EndCommand();
    }
}