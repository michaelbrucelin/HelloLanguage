# use for 15-unittest.py

def get_formatted_name(first, last, middle=''):
    """生成简洁的姓名"""
    if middle:
        full_name = f"{first} {middle} {last}"
    else:
        full_name = f"{first} {last}"

    return full_name.title()


class AnonymousSurvey:
    """收集匿名调查问卷的答案"""

    def __init__(self, question):
        """存储一个问题，并为存储答案做准备"""
        self.question = question
        self.responses = []

    def show_question(self):
        """显示调查问卷"""
        print(self.question)

    def store_response(self, new_response):
        """存储单份调查答卷"""
        self.responses.append(new_response)

    def show_results(self):
        """显示收集到的所有答卷"""
        print("Survey results:")
        for response in self.responses:
            print(f"- {response}")
