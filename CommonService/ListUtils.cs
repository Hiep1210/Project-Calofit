using Calofit_Project.CommonService;
using System.Runtime.ConstrainedExecution;

namespace Calofit_Project.CommonService
{
    public static class ListUtils
    {
        private static readonly int pageSize = 10;
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                return true;
            }
            /* If this is a list, use the Count property for efficiency. 
             * The Count property is O(1) while IEnumerable.Count() is O(N). */
            var collection = enumerable as ICollection<T>;
            if (collection != null)
            {
                return collection.Count < 1;
            }
            return !enumerable.Any();
        }

        public static List<T> Filter<T>(this List<T> list, Func<T, bool> predicate)
        {
            return list.Where(predicate).ToList();
        }

        public static List<T> Paging<T>(List<T> list, int PageIndex)
        {
            if (IsNullOrEmpty(list))
            {
                return list;
            }
            if (PageIndex < 1) PageIndex = 1;

            int TotalPage = (int)Math.Ceiling((double)list.Count() / pageSize);

            if (TotalPage > 0)
            {
                if (PageIndex > TotalPage) PageIndex = TotalPage;
                //_startIndex = (PageIndex - 1) * _pageSize + 1;

                list = list.Skip((PageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            return list;
        }
    }
}
    
