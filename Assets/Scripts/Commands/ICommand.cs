using System.Collections;
using UnityEngine;

public interface ICommand<T>
{
    IEnumerator execute(T data);
}