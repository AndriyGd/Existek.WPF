using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelDomain.Models;
using CommonMVVM.Common;

namespace WPF.Lesson19.ViewModels
{
    class NewEditBookViewModel
    {
        public IBook Book { get; set; }

        /// <summary>
        /// OK
        /// </summary>
        public DelegateCommand CloseCommand { get; set; }
        /// <summary>
        /// Cancel
        /// </summary>
        public DelegateCommand CancelCommand { get; set; }

        public NewEditBookViewModel(IBook book)
        {
            Book = book;
            CancelCommand = new DelegateCommand(p => {});
            CloseCommand = new DelegateCommand(p => { }, CanClose);
        }

        private bool CanClose(object obj)
        {
            return !string.IsNullOrWhiteSpace(Book.BookName)
                   && !string.IsNullOrWhiteSpace(Book.Author)
                   && Book.Pages > 0 && Book.PublishYear > 0;
        }
    }
}
