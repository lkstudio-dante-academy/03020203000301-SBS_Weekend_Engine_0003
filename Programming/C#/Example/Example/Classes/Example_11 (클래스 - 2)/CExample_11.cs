//#define E11_CLASS_01
//#define E11_CLASS_02
#define E11_CLASS_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Classes.Example_11
{
	class CExample_11
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if E11_CLASS_01
			/*
			 * 아래와 같이 프로퍼티를 활용하면 변수를 다루듯이 명령문을 작성하는
			 * 것이 가능하다.
			 */
			CCharacter oCharacter = new CCharacter();
			oCharacter.LV = 1;
			oCharacter.HP = 10;
			oCharacter.ATK = 5;
			oCharacter.Name = "캐릭터";

			Console.WriteLine("=====> 캐릭터 <=====");
			oCharacter.ShowInfo();
#elif E11_CLASS_02
			CArray oValues = new CArray(5);
			Random oRandom = new Random();

			for(int i = 0; i < 10; ++i)
			{
				oValues.AddVal(oRandom.Next(1, 100));
			}

			Console.WriteLine("=====> 배열 <=====");

			for(int i = 0; i < oValues.NumValues; ++i)
			{
				Console.Write("{0}, ", oValues[i]);
			}

			Console.WriteLine();
#elif E11_CLASS_03
			CData.m_fVal = 3.14f;

			CData oDataA = new CData();
			oDataA.m_nVal = 10;

			CData oDataB = new CData();
			oDataB.m_nVal = 20;

			CData.m_fVal = 6.14f;

			Console.WriteLine("=====> 데이터 A <=====");
			oDataA.ShowInfo();

			Console.WriteLine("\n=====> 데이터 B <=====");
			oDataB.ShowInfo();

			Console.WriteLine("\n=====> 데이터 클래스 <=====");
			CData.ShowStaticInfo();

			CDataStorage oStorageA = CDataStorage.GetInst();
			oStorageA.m_nVal = 10;

			CDataStorage oStorageB = CDataStorage.GetInst();
			oStorageB.m_nVal = 20;

			Console.WriteLine("\n=====> 데이터 저장소 A <=====");
			Console.WriteLine("{0}", oStorageA.m_nVal);

			Console.WriteLine("\n=====> 데이터 저장소 B <=====");
			Console.WriteLine("{0}", oStorageB.m_nVal);
#endif
		}

#if E11_CLASS_01
		/*
		 * 프로퍼티란?
		 * - C# 이 제공하는 접근자 메서드를 구현 할 수 있는 기능을 의미한다. (즉,
		 * 프로퍼티를 활용하면 접근자 메서드를 좀 더 수월하게 구현하는 것이 
		 * 가능하다.)
		 * 
		 * 전통적인 접근자 메서드는 메서드를 통해서 구현되기 때문에 멤버가 많아질수록
		 * 접근자 메서드도 같이 늘어나는 단점이 존재한다.
		 * 
		 * 또한, 메서드를 통해서 멤버에 간접적으로 접근하기 때문에 가독성이 떨어지는
		 * 단점도 존재한다.
		 * 
		 * 따라서, C# 은 프로퍼티를 제공하며 해당 기능을 활용하면 전통적인 방식에
		 * 비해 명령문을 좀 더 간결하게 작성하는 가능하다.
		 * 
		 * Ex)
		 * class CSomeClass
		 * {
		 *		private int m_nVal = 0;
		 *		
		 *		public int Val
		 *		{
		 *			get
		 *			{
		 *				return m_nVal;
		 *			}
		 *			set
		 *			{
		 *				m_nVal = value;
		 *			}
		 *		}
		 * }
		 * 
		 * CSomeClass oSomeObj = new CSomeClass();
		 * oSomeObj.Val = 10;
		 * 
		 * 위와 같이 프로퍼티를 활용하면 변수에 접근하는 듯이 명령문을 작성하는
		 * 것이 가능하다. (즉, 전통적인 방식에 비해 가독성이 향상된다는 것을
		 * 알 수 있다.)
		 */
		/** 캐릭터 */
		private class CCharacter
		{
			private int m_nLV = 0;
			private int m_nHP = 0;
			private int m_nATK = 0;

			/*
			 * 자동 구현 프로퍼티란?
			 * - 일반적인 프로퍼티와 달리 데이터를 저장하기 위한 멤버 변수를 자동으로
			 * 선언해주는 프로퍼티를 의미한다. (즉, 프로퍼티 자체는 멤버 변수에 접근하기
			 * 위한 수단이기 때문에 별도의 멤버 변수가 필요하다는 것을 알 수 있다.)
			 * 
			 * 단, 자동 구현 프로퍼티는 가장 단순한 형태의 접근자 메서드만을 구현해주기
			 * 때문에 Getter 와 Setter 가 동작하는 과정에서 추가적인 명령문을 작성하는
			 * 것이 불가능하다는 단점이 존재한다. (즉, 단순하게 값을 설정하거나 가져오는
			 * 것만 가능하다.)
			 */
			public string Name { get; set; } = string.Empty;

			public int LV
			{
				get
				{
					return m_nLV;
				}
				set
				{
					m_nLV = value;
				}
			}

			public int HP
			{
				get
				{
					return m_nHP;
				}
				set
				{
					m_nHP = value;
				}
			}

			public int ATK
			{
				get
				{
					return m_nATK;
				}
				set
				{
					m_nATK = value;
				}
			}

			/** 정보를 출력한다 */
			public void ShowInfo()
			{
				Console.WriteLine("LV : {0}", this.LV);
				Console.WriteLine("HP : {0}", this.HP);
				Console.WriteLine("ATK : {0}", this.ATK);
				Console.WriteLine("Name : {0}", this.Name);
			}
		}
#elif E11_CLASS_02
		/** 배열 */
		private class CArray
		{
			private int[] m_oValues = null;

			public int NumValues { get; private set; } = 0;

			/** 생성자 */
			public CArray(int a_nSize)
			{
				m_oValues = new int[a_nSize];
			}

			/*
			 * 인덱서란?
			 * - 객체를 대상으로 [] (인덱스 연산자) 를 사용 할 수 있게 해주는 기능을
			 * 의미한다. (즉, 인덱서를 활용하면 객체를 배열처럼 제어하는 것이 가능하다.)
			 */
			/** 인덱서 */
			public int this[int a_nIdx]
			{
				get
				{
					return m_oValues[a_nIdx];
				}
				set
				{
					m_oValues[a_nIdx] = value;
				}
			}

			/** 값을 추가한다 */
			public void AddVal(int a_nVal)
			{
				// 배열이 가득찼을 경우
				if(this.NumValues >= m_oValues.Length)
				{
					Array.Resize(ref m_oValues, m_oValues.Length * 2);
				}

				m_oValues[this.NumValues++] = a_nVal;
			}
		}
#elif E11_CLASS_03
		/* 클래스 (정적) 멤버란?
		 * - 객체에 종속되는 일반적인 멤버와 달리 클래스 자체에 종속되는 멤버를
		 * 의미한다. (즉, 클래스 멤버는 클래스 별로 하나만 존재한다는 것을
		 * 알 수 있다.)
		 * 
		 * 클래스 멤버에 접근하기 위해서는 객체를 생성 할 필요가 없다. (즉,
		 * 일반적인 멤버는 객체를 통해 접근하는 것이 가능하지만 클래스 멤버는
		 * 클래스만으로 접근하는 것이 가능하다.)
		 * 
		 * 또한, 클래스 멤버는 해당 클래스를 통해 생성 된 객체들이 공유하는 특징이
		 * 있기 때문에 클래스 멤버는 전역 멤버처럼 사용하는 것이 가능하다.
		 * 
		 * C# 클래스 멤버 선언 방법
		 * - static + 자료형 + 변수 이름								<- 클래스 변수
		 * - static + 반환형 + 메서드 이름 + 매개 변수 + 메서드 몸체	<- 클래스 메서드
		 * 
		 * 위와 같이 멤버 앞에 static 키워드를 명시하면 해당 멤버는 클래스에 종속되는
		 * 클래스 멤버라는 것을 의미한다.
		 */
		/** 데이터 */
		private class CData
		{
			public int m_nVal = 0;
			public static float m_fVal = 0.0f;

			/** 정보를 출력한다 */
			public void ShowInfo()
			{
				Console.WriteLine("정수 : {0}", m_nVal);
				Console.WriteLine("실수 : {0}", m_fVal);
			}

			/** 정보를 출력한다 */
			public static void ShowStaticInfo()
			{
				/*
				 * 클래스 메서드 내부에서는 일반적인 멤버에 접근하는 것이 불가능하다.
				 * 
				 * 이는 일반적인 멤버는 객체에 종속되기 때문에 멤버 변수에 접근하기
				 * 위해서는 반드시 객체를 지정해줄 필요가 있는데 클래스 메서드에는
				 * 이러한 정보가 없기 때문이다. (즉, 클래스 메서드 내부에서는 this
				 * 키워드를 사용하는 것이 불가능하다.)
				 */
				//Console.WriteLine("정수 : {0}", m_nVal);

				Console.WriteLine("실수 : {0}", m_fVal);
			}
		}

		/** 데이터 저장소 */
		private class CDataStorage
		{
			public int m_nVal = 0;
			private static CDataStorage m_oInst = null;

			/** 생성자 */
			private CDataStorage()
			{
				// Do Something
			}

			/** 인스턴스를 반환한다 */
			public static CDataStorage GetInst()
			{
				// 인스턴스 생성이 필요 할 경우
				if(m_oInst == null)
				{
					m_oInst = new CDataStorage();
				}

				return m_oInst;
			}
		}
#endif
	}
}
