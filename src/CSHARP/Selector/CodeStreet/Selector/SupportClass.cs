//
// In order to convert some functionality to Visual C#, the Java Language Conversion Assistant
// creates "support classes" that duplicate the original functionality.  
//
// Support classes replicate the functionality of the original code, but in some cases they are 
// substantially different architecturally. Although every effort is made to preserve the 
// original architecture of the application in the converted project, the user should be aware that 
// the primary goal of these support classes is to replicate functionality, and that at times 
// the architecture of the resulting solution may differ somewhat.
//

using System;

namespace CodeStreet.Selector
{
	/// <summary>
	/// Contains conversion support elements such as classes, interfaces and static methods.
	/// </summary>
	public class SupportClass
	{
		/// <summary>
		/// The class performs token processing from strings
		/// </summary>
		public class Tokenizer
		{
			//Element list identified
			private System.Collections.ArrayList elements;
			//Source string to use
			private string source;
			//The tokenizer uses the default delimiter set: the space character, the tab character, the newline character, and the carriage-return character
			private string delimiters = " \t\n\r";		

			/// <summary>
			/// Initializes a new class instance with a specified string to process
			/// </summary>
			/// <param name="source">String to tokenize</param>
			public Tokenizer(string source)
			{			
				this.elements = new System.Collections.ArrayList();
				this.elements.AddRange(source.Split(this.delimiters.ToCharArray()));
				this.RemoveEmptyStrings();
				this.source = source;
			}

			/// <summary>
			/// Initializes a new class instance with a specified string to process
			/// and the specified token delimiters to use
			/// </summary>
			/// <param name="source">String to tokenize</param>
			/// <param name="delimiters">String containing the delimiters</param>
			public Tokenizer(string source, string delimiters)
			{
				this.elements = new System.Collections.ArrayList();
				this.delimiters = delimiters;
				this.elements.AddRange(source.Split(this.delimiters.ToCharArray()));
				this.RemoveEmptyStrings();
				this.source = source;
			}

			/// <summary>
			/// Current token count for the source string
			/// </summary>
			public int Count
			{
				get
				{
					return (this.elements.Count);
				}
			}

			/// <summary>
			/// Determines if there are more tokens to return from the source string
			/// </summary>
			/// <returns>True or false, depending if there are more tokens</returns>
			public bool HasMoreTokens()
			{
				return (this.elements.Count > 0);			
			}

			/// <summary>
			/// Returns the next token from the token list
			/// </summary>
			/// <returns>The string value of the token</returns>
			public string NextToken()
			{			
				string result;
				if (source == "") throw new System.Exception();
				else
				{
					this.elements = new System.Collections.ArrayList();
					this.elements.AddRange(this.source.Split(delimiters.ToCharArray()));
					RemoveEmptyStrings();		
					result = (string) this.elements[0];
					this.elements.RemoveAt(0);				
					this.source = this.source.Remove(this.source.IndexOf(result),result.Length);
					this.source = this.source.TrimStart(this.delimiters.ToCharArray());
					return result;					
				}			
			}

			/// <summary>
			/// Returns the next token from the source string, using the provided
			/// token delimiters
			/// </summary>
			/// <param name="delimiters">String containing the delimiters to use</param>
			/// <returns>The string value of the token</returns>
			public string NextToken(string delimiters)
			{
				this.delimiters = delimiters;
				return NextToken();
			}

			/// <summary>
			/// Removes all empty strings from the token list
			/// </summary>
			private void RemoveEmptyStrings()
			{
				for (int index=0; index < this.elements.Count; index++)
					if ((string)this.elements[index]== "")
					{
						this.elements.RemoveAt(index);
						index--;
					}
			}
		}

		/*******************************/
		/// <summary>
		/// Writes the exception stack trace to the received stream
		/// </summary>
		/// <param name="throwable">Exception to obtain information from</param>
		/// <param name="stream">Output sream used to write to</param>
		public static void WriteStackTrace(System.Exception throwable, System.IO.TextWriter stream)
		{
			stream.Write(throwable.StackTrace);
			stream.Flush();
		}

		/*******************************/
		/// <summary>
		/// This class manages a set of elements.
		/// </summary>
		public class SetSupport : System.Collections.ArrayList
		{
			/// <summary>
			/// Creates a new set.
			/// </summary>
			public SetSupport(): base()
			{           
			}

			/// <summary>
			/// Creates a new set initialized with System.Collections.ICollection object
			/// </summary>
			/// <param name="collection">System.Collections.ICollection object to initialize the set object</param>
			public SetSupport(System.Collections.ICollection collection): base(collection)
			{           
			}

			/// <summary>
			/// Creates a new set initialized with a specific capacity.
			/// </summary>
			/// <param name="capacity">value to set the capacity of the set object</param>
			public SetSupport(int capacity): base(capacity)
			{           
			}
		 
			/// <summary>
			/// Adds an element to the set.
			/// </summary>
			/// <param name="objectToAdd">The object to be added.</param>
			/// <returns>True if the object was added, false otherwise.</returns>
			public new virtual bool Add(object objectToAdd)
			{
				if (this.Contains(objectToAdd))
					return false;
				else
				{
					base.Add(objectToAdd);
					return true;
				}
			}
		 
			/// <summary>
			/// Adds all the elements contained in the specified collection.
			/// </summary>
			/// <param name="collection">The collection used to extract the elements that will be added.</param>
			/// <returns>Returns true if all the elements were successfuly added. Otherwise returns false.</returns>
			public virtual bool AddAll(System.Collections.ICollection collection)
			{
				bool result = false;
				if (collection!=null)
				{
					System.Collections.IEnumerator tempEnumerator = new System.Collections.ArrayList(collection).GetEnumerator();
					while (tempEnumerator.MoveNext())
					{
						if (tempEnumerator.Current != null)
							result = this.Add(tempEnumerator.Current);
					}
				}
				return result;
			}
			
			/// <summary>
			/// Adds all the elements contained in the specified support class collection.
			/// </summary>
			/// <param name="collection">The collection used to extract the elements that will be added.</param>
			/// <returns>Returns true if all the elements were successfuly added. Otherwise returns false.</returns>
			public virtual bool AddAll(CollectionSupport collection)
			{
				return this.AddAll((System.Collections.ICollection)collection);
			}
		 
			/// <summary>
			/// Verifies that all the elements of the specified collection are contained into the current collection. 
			/// </summary>
			/// <param name="collection">The collection used to extract the elements that will be verified.</param>
			/// <returns>True if the collection contains all the given elements.</returns>
			public virtual bool ContainsAll(System.Collections.ICollection collection)
			{
				bool result = false;
				System.Collections.IEnumerator tempEnumerator = collection.GetEnumerator();
				while (tempEnumerator.MoveNext())
					if (!(result = this.Contains(tempEnumerator.Current)))
						break;
				return result;
			}
			
			/// <summary>
			/// Verifies if all the elements of the specified collection are contained into the current collection.
			/// </summary>
			/// <param name="collection">The collection used to extract the elements that will be verified.</param>
			/// <returns>Returns true if all the elements are contained in the collection. Otherwise returns false.</returns>
			public virtual bool ContainsAll(CollectionSupport collection)
			{
				return this.ContainsAll((System.Collections.ICollection) collection);
			}		
		 
			/// <summary>
			/// Verifies if the collection is empty.
			/// </summary>
			/// <returns>True if the collection is empty, false otherwise.</returns>
			public virtual bool IsEmpty()
			{
				return (this.Count == 0);
			}
		 	 
			/// <summary>
			/// Removes an element from the set.
			/// </summary>
			/// <param name="elementToRemove">The element to be removed.</param>
			/// <returns>True if the element was removed.</returns>
			public new virtual bool Remove(object elementToRemove)
			{
				bool result = false;
				if (this.Contains(elementToRemove))
					result = true;
				base.Remove(elementToRemove);
				return result;
			}
			
			/// <summary>
			/// Removes all the elements contained in the specified collection.
			/// </summary>
			/// <param name="collection">The collection used to extract the elements that will be removed.</param>
			/// <returns>True if all the elements were successfuly removed, false otherwise.</returns>
			public virtual bool RemoveAll(System.Collections.ICollection collection)
			{ 
				bool result = false;
				System.Collections.IEnumerator tempEnumerator = collection.GetEnumerator();
				while (tempEnumerator.MoveNext())
				{
					if ((result == false) && (this.Contains(tempEnumerator.Current)))
						result = true;
					this.Remove(tempEnumerator.Current);
				}
				return result;
			}
			
			/// <summary>
			/// Removes all the elements contained into the specified collection.
			/// </summary>
			/// <param name="collection">The collection used to extract the elements that will be removed.</param>
			/// <returns>Returns true if all the elements were successfuly removed. Otherwise returns false.</returns>
			public virtual bool RemoveAll(CollectionSupport collection)
			{ 
				return this.RemoveAll((System.Collections.ICollection) collection);
			}		

			/// <summary>
			/// Removes all the elements that aren't contained in the specified collection.
			/// </summary>
			/// <param name="collection">The collection used to verify the elements that will be retained.</param>
			/// <returns>True if all the elements were successfully removed, false otherwise.</returns>
			public virtual bool RetainAll(System.Collections.ICollection collection)
			{
				bool result = false;
				System.Collections.IEnumerator tempEnumerator = collection.GetEnumerator();
				SetSupport tempSet = (SetSupport)collection;
				while (tempEnumerator.MoveNext())
					if (!tempSet.Contains(tempEnumerator.Current))
					{
						result = this.Remove(tempEnumerator.Current);
						tempEnumerator = this.GetEnumerator();
					}
				return result;
			}
			
			/// <summary>
			/// Removes all the elements that aren't contained into the specified collection.
			/// </summary>
			/// <param name="collection">The collection used to verify the elements that will be retained.</param>
			/// <returns>Returns true if all the elements were successfully removed. Otherwise returns false.</returns>
			public virtual bool RetainAll(CollectionSupport collection)
			{
				return this.RetainAll((System.Collections.ICollection) collection);
			}		
		 
			/// <summary>
			/// Obtains an array containing all the elements of the collection.
			/// </summary>
			/// <returns>The array containing all the elements of the collection.</returns>
			public new virtual object[] ToArray()
			{
				int index = 0;
				object[] tempObject= new object[this.Count];
				System.Collections.IEnumerator tempEnumerator = this.GetEnumerator();
				while (tempEnumerator.MoveNext())
					tempObject[index++] = tempEnumerator.Current;
				return tempObject;
			}

			/// <summary>
			/// Obtains an array containing all the elements in the collection.
			/// </summary>
			/// <param name="objects">The array into which the elements of the collection will be stored.</param>
			/// <returns>The array containing all the elements of the collection.</returns>
			public virtual object[] ToArray(object[] objects)
			{
				int index = 0;
				System.Collections.IEnumerator tempEnumerator = this.GetEnumerator();
				while (tempEnumerator.MoveNext())
					objects[index++] = tempEnumerator.Current;
				return objects;
			}
		}
		/*******************************/
		/// <summary>
		/// This class manages different operation with collections.
		/// </summary>
		public class AbstractSetSupport : SetSupport
		{
			/// <summary>
			/// The constructor with no parameters to create an abstract set.
			/// </summary>
			public AbstractSetSupport()
			{
			}
		}


		/*******************************/
		/// <summary> 
		/// This class manages a hash set of elements.
		/// </summary>
		public class HashSetSupport : AbstractSetSupport
		{
			/// <summary>
			/// Creates a new hash set collection.
			/// </summary>
			public HashSetSupport()
			{     
			}
		       
			/// <summary>
			/// Creates a new hash set collection.
			/// </summary>
			/// <param name="collection">The collection to initialize the hash set with.</param>
			public HashSetSupport(System.Collections.ICollection collection)
			{
				this.AddRange(collection);
			}
		       
			/// <summary>
			/// Creates a new hash set with the given capacity.
			/// </summary>
			/// <param name="capacity">The initial capacity of the hash set.</param>
			public HashSetSupport(int capacity)
			{
				this.Capacity = capacity;
			}
		    
			/// <summary>
			/// Creates a new hash set with the given capacity.
			/// </summary>
			/// <param name="capacity">The initial capacity of the hash set.</param>
			/// <param name="loadFactor">The load factor of the hash set.</param>
			public HashSetSupport(int capacity, float loadFactor)
			{
				this.Capacity = capacity;
			}

			/// <summary>
			/// Creates a copy of the HashSetSupport.
			/// </summary>
			/// <returns> A copy of the HashSetSupport.</returns>
			public virtual object HashSetClone()
			{
				return MemberwiseClone();
			}
		}
		/*******************************/
		/// <summary>
		/// This class contains different methods to manage Collections.
		/// </summary>
		public class CollectionSupport : System.Collections.CollectionBase
		{
			/// <summary>
			/// Creates an instance of the Collection by using an inherited constructor.
			/// </summary>
			public CollectionSupport() : base()
			{			
			}

			/// <summary>
			/// Adds an specified element to the collection.
			/// </summary>
			/// <param name="element">The element to be added.</param>
			/// <returns>Returns true if the element was successfuly added. Otherwise returns false.</returns>
			public virtual bool Add(System.Object element)
			{
				return (this.List.Add(element) != -1);
			}	

			/// <summary>
			/// Adds all the elements contained in the specified collection.
			/// </summary>
			/// <param name="collection">The collection used to extract the elements that will be added.</param>
			/// <returns>Returns true if all the elements were successfuly added. Otherwise returns false.</returns>
			public virtual bool AddAll(System.Collections.ICollection collection)
			{
				bool result = false;
				if (collection!=null)
				{
					System.Collections.IEnumerator tempEnumerator = new System.Collections.ArrayList(collection).GetEnumerator();
					while (tempEnumerator.MoveNext())
					{
						if (tempEnumerator.Current != null)
							result = this.Add(tempEnumerator.Current);
					}
				}
				return result;
			}


			/// <summary>
			/// Adds all the elements contained in the specified support class collection.
			/// </summary>
			/// <param name="collection">The collection used to extract the elements that will be added.</param>
			/// <returns>Returns true if all the elements were successfuly added. Otherwise returns false.</returns>
			public virtual bool AddAll(CollectionSupport collection)
			{
				return this.AddAll((System.Collections.ICollection)collection);
			}

			/// <summary>
			/// Verifies if the specified element is contained into the collection. 
			/// </summary>
			/// <param name="element"> The element that will be verified.</param>
			/// <returns>Returns true if the element is contained in the collection. Otherwise returns false.</returns>
			public virtual bool Contains(System.Object element)
			{
				return this.List.Contains(element);
			}

			/// <summary>
			/// Verifies if all the elements of the specified collection are contained into the current collection.
			/// </summary>
			/// <param name="collection">The collection used to extract the elements that will be verified.</param>
			/// <returns>Returns true if all the elements are contained in the collection. Otherwise returns false.</returns>
			public virtual bool ContainsAll(System.Collections.ICollection collection)
			{
				bool result = false;
				System.Collections.IEnumerator tempEnumerator = new System.Collections.ArrayList(collection).GetEnumerator();
				while (tempEnumerator.MoveNext())
					if (!(result = this.Contains(tempEnumerator.Current)))
						break;
				return result;
			}

			/// <summary>
			/// Verifies if all the elements of the specified collection are contained into the current collection.
			/// </summary>
			/// <param name="collection">The collection used to extract the elements that will be verified.</param>
			/// <returns>Returns true if all the elements are contained in the collection. Otherwise returns false.</returns>
			public virtual bool ContainsAll(CollectionSupport collection)
			{
				return this.ContainsAll((System.Collections.ICollection) collection);
			}

			/// <summary>
			/// Verifies if the collection is empty.
			/// </summary>
			/// <returns>Returns true if the collection is empty. Otherwise returns false.</returns>
			public virtual bool IsEmpty()
			{
				return (this.Count == 0);
			}

			/// <summary>
			/// Removes an specified element from the collection.
			/// </summary>
			/// <param name="element">The element to be removed.</param>
			/// <returns>Returns true if the element was successfuly removed. Otherwise returns false.</returns>
			public virtual bool Remove(System.Object element)
			{
				bool result = false;
				if (this.Contains(element))
				{
					this.List.Remove(element);
					result = true;
				}
				return result;
			}

			/// <summary>
			/// Removes all the elements contained into the specified collection.
			/// </summary>
			/// <param name="collection">The collection used to extract the elements that will be removed.</param>
			/// <returns>Returns true if all the elements were successfuly removed. Otherwise returns false.</returns>
			public virtual bool RemoveAll(System.Collections.ICollection collection)
			{ 
				bool result = false;
				System.Collections.IEnumerator tempEnumerator = new System.Collections.ArrayList(collection).GetEnumerator();
				while (tempEnumerator.MoveNext())
				{
					if (this.Contains(tempEnumerator.Current))
						result = this.Remove(tempEnumerator.Current);
				}
				return result;
			}

			/// <summary>
			/// Removes all the elements contained into the specified collection.
			/// </summary>
			/// <param name="collection">The collection used to extract the elements that will be removed.</param>
			/// <returns>Returns true if all the elements were successfuly removed. Otherwise returns false.</returns>
			public virtual bool RemoveAll(CollectionSupport collection)
			{ 
				return this.RemoveAll((System.Collections.ICollection) collection);
			}

			/// <summary>
			/// Removes all the elements that aren't contained into the specified collection.
			/// </summary>
			/// <param name="collection">The collection used to verify the elements that will be retained.</param>
			/// <returns>Returns true if all the elements were successfully removed. Otherwise returns false.</returns>
			public virtual bool RetainAll(System.Collections.ICollection collection)
			{
				bool result = false;
				System.Collections.IEnumerator tempEnumerator = this.GetEnumerator();
				CollectionSupport tempCollection = new CollectionSupport();
				tempCollection.AddAll(collection);
				while (tempEnumerator.MoveNext())
					if (!tempCollection.Contains(tempEnumerator.Current))
					{
						result = this.Remove(tempEnumerator.Current);
						
						if (result == true)
						{
							tempEnumerator = this.GetEnumerator();
						}
					}
				return result;
			}

			/// <summary>
			/// Removes all the elements that aren't contained into the specified collection.
			/// </summary>
			/// <param name="collection">The collection used to verify the elements that will be retained.</param>
			/// <returns>Returns true if all the elements were successfully removed. Otherwise returns false.</returns>
			public virtual bool RetainAll(CollectionSupport collection)
			{
				return this.RetainAll((System.Collections.ICollection) collection);
			}

			/// <summary>
			/// Obtains an array containing all the elements of the collection.
			/// </summary>
			/// <returns>The array containing all the elements of the collection</returns>
			public virtual System.Object[] ToArray()
			{	
				int index = 0;
				System.Object[] objects = new System.Object[this.Count];
				System.Collections.IEnumerator tempEnumerator = this.GetEnumerator();
				while (tempEnumerator.MoveNext())
					objects[index++] = tempEnumerator.Current;
				return objects;
			}

			/// <summary>
			/// Obtains an array containing all the elements of the collection.
			/// </summary>
			/// <param name="objects">The array into which the elements of the collection will be stored.</param>
			/// <returns>The array containing all the elements of the collection.</returns>
			public virtual System.Object[] ToArray(System.Object[] objects)
			{	
				int index = 0;
				System.Collections.IEnumerator tempEnumerator = this.GetEnumerator();
				while (tempEnumerator.MoveNext())
					objects[index++] = tempEnumerator.Current;
				return objects;
			}

			/// <summary>
			/// Creates a CollectionSupport object with the contents specified in array.
			/// </summary>
			/// <param name="array">The array containing the elements used to populate the new CollectionSupport object.</param>
			/// <returns>A CollectionSupport object populated with the contents of array.</returns>
			public static CollectionSupport ToCollectionSupport(System.Object[] array)
			{
				CollectionSupport tempCollectionSupport = new CollectionSupport();             
				tempCollectionSupport.AddAll(array);
				return tempCollectionSupport;
			}
		}

		/*******************************/
		/// <summary>
		/// This method returns the literal value received
		/// </summary>
		/// <param name="literal">The literal to return</param>
		/// <returns>The received value</returns>
		public static long Identity(long literal)
		{
			return literal;
		}

		/// <summary>
		/// This method returns the literal value received
		/// </summary>
		/// <param name="literal">The literal to return</param>
		/// <returns>The received value</returns>
		public static ulong Identity(ulong literal)
		{
			return literal;
		}

		/// <summary>
		/// This method returns the literal value received
		/// </summary>
		/// <param name="literal">The literal to return</param>
		/// <returns>The received value</returns>
		public static float Identity(float literal)
		{
			return literal;
		}

		/// <summary>
		/// This method returns the literal value received
		/// </summary>
		/// <param name="literal">The literal to return</param>
		/// <returns>The received value</returns>
		public static double Identity(double literal)
		{
			return literal;
		}
	}
}
